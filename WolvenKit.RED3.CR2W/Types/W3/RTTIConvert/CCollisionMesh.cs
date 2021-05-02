using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CCollisionMesh : CResource
	{
		[Ordinal(1)] [RED("shapes", 2,0)] 		public CArray<CPtr<ICollisionShape>> Shapes { get; set;}

		[Ordinal(2)] [RED("occlusionAttenuation")] 		public CFloat OcclusionAttenuation { get; set;}

		[Ordinal(3)] [RED("occlusionDiagonalLimit")] 		public CFloat OcclusionDiagonalLimit { get; set;}

		[Ordinal(4)] [RED("swimmingRotationAxis")] 		public CInt32 SwimmingRotationAxis { get; set;}

		public CCollisionMesh(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CCollisionMesh(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}