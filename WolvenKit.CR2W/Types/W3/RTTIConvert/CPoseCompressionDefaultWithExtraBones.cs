using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CPoseCompressionDefaultWithExtraBones : CPoseCompressionDefault
	{
		[RED("extraRotBones", 2,0)] 		public CArray<CInt32> ExtraRotBones { get; set;}

		[RED("extraTransBones", 2,0)] 		public CArray<CInt32> ExtraTransBones { get; set;}

		public CPoseCompressionDefaultWithExtraBones(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CPoseCompressionDefaultWithExtraBones(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}