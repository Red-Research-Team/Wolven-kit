using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CStaticMeshComponent : CMeshComponent
	{
		[RED("pathLibCollisionType")] 		public CEnum<EPathLibCollision> PathLibCollisionType { get; set;}

		[RED("fadeOnCameraCollision")] 		public CBool FadeOnCameraCollision { get; set;}

		[RED("physicalCollisionType")] 		public CPhysicalCollision PhysicalCollisionType { get; set;}

		public CStaticMeshComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CStaticMeshComponent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}