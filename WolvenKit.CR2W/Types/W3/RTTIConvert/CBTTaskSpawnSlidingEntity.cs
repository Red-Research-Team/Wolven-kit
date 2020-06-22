using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskSpawnSlidingEntity : CBTTaskSpawnEntityOffset
	{
		[RED("component")] 		public CHandle<CComponent> Component { get; set;}

		[RED("slideComponent")] 		public CHandle<W3SlideToTargetComponent> SlideComponent { get; set;}

		[RED("targetNode")] 		public CHandle<CNode> TargetNode { get; set;}

		[RED("timeToFollow")] 		public CInt32 TimeToFollow { get; set;}

		[RED("timeStamp")] 		public CFloat TimeStamp { get; set;}

		[RED("destroyAfter")] 		public CFloat DestroyAfter { get; set;}

		[RED("destroyAfterTimerEnds")] 		public CBool DestroyAfterTimerEnds { get; set;}

		[RED("destroyOnDeactivate")] 		public CBool DestroyOnDeactivate { get; set;}

		public CBTTaskSpawnSlidingEntity(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskSpawnSlidingEntity(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}