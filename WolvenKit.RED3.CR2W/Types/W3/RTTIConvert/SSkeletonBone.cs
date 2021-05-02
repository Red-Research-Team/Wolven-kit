using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SSkeletonBone : CVariable
	{
		[Ordinal(1)] [RED("name")] 		public StringAnsi Name { get; set;}

		[Ordinal(2)] [RED("nameAsCName")] 		public CName NameAsCName { get; set;}

		[Ordinal(3)] [RED("flags")] 		public CEnum<ESkeletonBoneFlags> Flags { get; set;}

		public SSkeletonBone(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SSkeletonBone(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}