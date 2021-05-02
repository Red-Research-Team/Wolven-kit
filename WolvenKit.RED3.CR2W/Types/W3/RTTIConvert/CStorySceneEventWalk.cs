using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CStorySceneEventWalk : CStorySceneEventCurveAnimation
	{
		[Ordinal(1)] [RED("actorName")] 		public CName ActorName { get; set;}

		[Ordinal(2)] [RED("animationStartName")] 		public CName AnimationStartName { get; set;}

		[Ordinal(3)] [RED("animationLoopName")] 		public CName AnimationLoopName { get; set;}

		[Ordinal(4)] [RED("animationStopName")] 		public CName AnimationStopName { get; set;}

		public CStorySceneEventWalk(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CStorySceneEventWalk(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}