﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using WolvenKit.CR2W.Reflection;

namespace WolvenKit.CR2W.Types
{
    public class CR2WTypeDefinition
    {
        public string name;
        public CVariable var;

        public CR2WTypeDefinition(string name, CVariable var)
        {
            this.name = name;
            this.var = var;
        }
    }

    public static class CR2WTypeManager
    {
        public static List<string> AvailableTypes
        {
            get
            {
                // class names
                string nspace = "WolvenKit.CR2W.Types";
                List<string> classNames = new List<string>();

                var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where t.IsClass && t.Namespace == nspace
                        select t;
                q.ToList().ForEach(t => classNames.Add(t.Name));

                // enum names
                List<string> enumNames = new List<string>();
                foreach (var enm in typeof(Enums).GetNestedTypes())
                {
                    enumNames.Add(enm.Name);
                }

                return classNames.Concat(enumNames).ToList();
            }
        }

        public static CVariable Create(string typename, string varname, CR2WFile cr2w, CVariable parentVariable, bool readUnknownAsBytes = true)
        {
            CVariable variable = CreateInner(typename, varname, cr2w, parentVariable, readUnknownAsBytes);
            
            return variable;
        }


        private static CVariable CreateInner(string typename, string varname, CR2WFile cr2w, CVariable parentVariable, bool readUnknownAsBytes = true)
        {


            #region ENUMS
            if (typeof(Enums).GetNestedTypes().Select(_ => _.Name).Contains(typename))
            {
                Enum e = (Enum)Activator.CreateInstance(typeof(Enums).GetNestedTypes().FirstOrDefault(_ => _.Name == typename));

                if (e.GetType().IsDefined(typeof(FlagsAttribute), false))
                {
                    typename = REDReflection.GetWKitTypeFromREDType(typename);
                    var etype = Type.GetType($"WolvenKit.CR2W.Types.{typename}");
                    object einstance = Activator.CreateInstance(etype, cr2w);
                    return einstance as CVariable;
                }

                var cenum = MakeGenericEnumType(typeof(CEnum<>), e);
                return cenum;
            }

            #endregion


            #region GENERIC TYPES
            var fullname = typename;

            // match pattern e.g. 
            // (handle):(CGenericGrassMask) or 
            // (array):(2,0,handle:CBitmapTexture)
            var reg = new Regex(@"^(\w+):(.+)$"); 
            var match = reg.Match(typename);
            if (match.Success)
            {
                switch (match.Groups[1].Value)
                {
                    case "CHandle":
                    case "handle":
                        {
                            CVariable innerobject = CreateInner(match.Groups[2].Value, "", cr2w, null);
                            return MakeGenericType(typeof(CHandle<>), innerobject);
                        }
                    case "CPtr":
                    case "ptr":
                        {
                            CVariable innerobject = CreateInner(match.Groups[2].Value, "", cr2w, null);
                            return MakeGenericType(typeof(CPtr<>), innerobject);
                        }
                    case "CSoft":
                    case "soft":
                        {
                            CVariable innerobject = CreateInner(match.Groups[2].Value, "", cr2w, null);
                            return MakeGenericType(typeof(CSoft<>), innerobject);
                        }
                    case "array":
                        {
                            typename = match.Groups[1].Value;

                            // match pattern e.g. 
                            // array:   (2),(0),(handle:CBitmapTexture)
                            var regArrayType = new Regex(@"(\d+),(\d+),(.+)");
                            var matchArrayType = regArrayType.Match(fullname);
                            if (matchArrayType.Success)
                            {
                                //byte arrays, these can be huge, using ordinary arrays is just too slow.
                                if (matchArrayType.Groups[3].Value == "Uint8" || matchArrayType.Groups[3].Value == "Int8")
                                {
                                    var bytearray = new CByteArray(cr2w, parentVariable, varname);
                                    //bytearray.Type = fullname;
                                    return bytearray;
                                }

                                CVariable innerobject = CreateInner(matchArrayType.Groups[3].Value, "", cr2w, null);
                                var arrayacc = MakeArray(innerobject);
                                arrayacc.Flags = new List<int>() { int.Parse(matchArrayType.Groups[1].Value), int.Parse(matchArrayType.Groups[2].Value) };
                                return arrayacc as CVariable;
                            }
                            else
                            {
                                //#region FIXED SIZE ARRAYS
                                //// match pattern e.g. 
                                //// [(1)](Bezier2dHandle)
                                //var regFixedSizeArray = new Regex(@"^\[(\d+)\](.+)$");
                                //var matchFixedSizeArray = regFixedSizeArray.Match(typename);
                                //if (matchFixedSizeArray.Success)
                                //{
                                //    CVariable innerobject = Create(matchFixedSizeArray.Groups[2].Value, cr2w);
                                //    var arrayacc = MakeArray(innerobject);
                                //    arrayacc.Flags = new List<int>() { int.Parse(matchFixedSizeArray.Groups[1].Value) };
                                //    return arrayacc as CVariable;
                                //}
                                //#endregion


                                //throw new InvalidParsingException($"Invalid array type format: typename: {typename}.");
                                CVariable innerobject = CreateInner(match.Groups[2].Value, "", cr2w, null);
                                return MakeGenericType(typeof(CArray<>), innerobject);
                            }
                        }
                    case "static":
                        {
                            typename = match.Groups[1].Value;

                            // match pattern e.g. 
                            // static:  (4),(Uint32)
                            var regArrayType = new Regex(@"(\d+),(.+)");
                            var matchArrayType = regArrayType.Match(fullname);
                            if (matchArrayType.Success)
                            {
                                // byte arrays, these can be huge, using ordinary arrays is just too slow.
                                if (matchArrayType.Groups[2].Value == "Uint8" || matchArrayType.Groups[2].Value == "Int8")
                                {
                                    throw new NotImplementedException();
                                    //return new CByteArray(cr2w);
                                }

                                CVariable innerobject = CreateInner(matchArrayType.Groups[2].Value, "", cr2w, null);
                                var arrayacc = MakeArray(innerobject);
                                arrayacc.Flags = new List<int>() { int.Parse(matchArrayType.Groups[1].Value) };
                                return arrayacc as CVariable;
                            }
                            else
                            {
                                throw new InvalidParsingException($"Invalid static type format: typename: {typename}.");
                            }
                        }
                    case "CBufferUInt16":
                        {
                            CVariable innerobject = CreateInner(match.Groups[2].Value, "", cr2w, null);
                            return MakeGenericType(typeof(CBufferUInt16<>), innerobject);
                        }
                    case "CBufferVLQ":
                        {
                            CVariable innerobject = CreateInner(match.Groups[2].Value, "", cr2w, null);
                            return MakeGenericType(typeof(CBufferVLQ<>), innerobject);
                        }
                    case "CBufferVLQInt32":
                        {
                            CVariable innerobject = CreateInner(match.Groups[2].Value, "", cr2w, null);
                            return MakeGenericType(typeof(CBufferVLQInt32<>), innerobject);
                        }
                    case "CCompressedBuffer":
                        {
                            CVariable innerobject = CreateInner(match.Groups[2].Value, "", cr2w, null);
                            return MakeGenericType(typeof(CCompressedBuffer<>), innerobject);
                        }
                    case "CPaddedBuffer":
                        {
                            CVariable innerobject = CreateInner(match.Groups[2].Value, "", cr2w, null);
                            return MakeGenericType(typeof(CPaddedBuffer<>), innerobject);
                        }
                    case "CEnum":
                        {
                            Enum innerobject = CreateInnerEnum(match.Groups[2].Value);
                            return MakeGenericEnumType(typeof(CEnum<>), innerobject);
                        }
                    default:
                        typename = match.Groups[1].Value;
                        break;
                }
            }
            #endregion

            #region W3 TYPES 
            typename = REDReflection.GetWKitTypeFromREDType(typename);
            var type = Type.GetType($"WolvenKit.CR2W.Types.{typename}");
            object instance = Activator.CreateInstance(type, cr2w);
            #endregion


            // Unknown type, just interpret as bytes
            if (instance == null)
            {
                if (!cr2w.UnknownTypes.Contains(fullname))
                    cr2w.UnknownTypes.Add(fullname);

                if (readUnknownAsBytes)
                {
                    return new CBytes(cr2w, parentVariable, "unknown bytes");
                }
            }

            return instance as CVariable;



            #region LOCAL FUNCTIONS
            IArrayAccessor MakeArray(CVariable innerobject)
            {
                if (innerobject != null)
                {
                    Type elementType = typeof(CArray<>).MakeGenericType(innerobject.GetType());
                    var array = Activator.CreateInstance(elementType, cr2w, parentVariable, varname) as CVariable;
                    //innerobject.Parent = array;
                    return array as IArrayAccessor;
                }
                else
                {
                    throw new Exception();
                }
            }


            CVariable MakeGenericType(Type gentype, CVariable innerobject)
            {
                if (innerobject != null)
                {
                    Type elementType = gentype.MakeGenericType(innerobject.GetType());
                    CVariable handle = Activator.CreateInstance(elementType, cr2w, parentVariable, varname) as CVariable;
                    //innerobject.Parent = handle;
                    return handle;
                }
                else
                {
                    throw new Exception();
                }
            }

            CVariable MakeGenericEnumType(Type gentype, Enum innerobject)
            {
                if (innerobject != null)
                {
                    Type elementType = gentype.MakeGenericType(innerobject.GetType());
                    CVariable handle = Activator.CreateInstance(elementType, cr2w, parentVariable, varname) as CVariable;
                    return handle;
                }
                else
                {
                    throw new Exception();
                }
            }
            #endregion
        }

        private static Enum CreateInnerEnum(string value)
        {
            Enum e = (Enum)Activator.CreateInstance(typeof(Enums).GetNestedTypes().FirstOrDefault(_ => _.Name == value));

            if (e.GetType().IsDefined(typeof(FlagsAttribute), false))
            {
                throw new NotImplementedException(); 
            }

            return e;
        }
    }
}