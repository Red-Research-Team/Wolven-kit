using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CSkeletalAnimatedComponent : CComponent
	{
		[Ordinal(1)] [RED("skeleton")] 		public CHandle<CSkeleton> Skeleton { get; set;}

		[Ordinal(2)] [RED("animset")] 		public CHandle<CSkeletalAnimationSet> Animset { get; set;}

		[Ordinal(3)] [RED("controller")] 		public CPtr<IAnimationController> Controller { get; set;}

		[Ordinal(4)] [RED("processEvents")] 		public CBool ProcessEvents { get; set;}

		public CSkeletalAnimatedComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CSkeletalAnimatedComponent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}