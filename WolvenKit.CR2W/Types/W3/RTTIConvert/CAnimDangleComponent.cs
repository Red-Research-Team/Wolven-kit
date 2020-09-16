using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CAnimDangleComponent : CComponent
	{
		[Ordinal(1)] [RED("constraint")] 		public CPtr<IAnimDangleConstraint> Constraint { get; set;}

		[Ordinal(2)] [RED("attPrio")] 		public CInt32 AttPrio { get; set;}

		[Ordinal(3)] [RED("debugRender")] 		public CBool DebugRender { get; set;}

		public CAnimDangleComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CAnimDangleComponent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}