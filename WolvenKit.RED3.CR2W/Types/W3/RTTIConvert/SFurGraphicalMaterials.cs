using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SFurGraphicalMaterials : CVariable
	{
		[Ordinal(1)] [RED("color")] 		public SFurColor Color { get; set;}

		[Ordinal(2)] [RED("diffuse")] 		public SFurDiffuse Diffuse { get; set;}

		[Ordinal(3)] [RED("specular")] 		public SFurSpecular Specular { get; set;}

		[Ordinal(4)] [RED("glint")] 		public SFurGlint Glint { get; set;}

		[Ordinal(5)] [RED("shadow")] 		public SFurShadow Shadow { get; set;}

		public SFurGraphicalMaterials(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}