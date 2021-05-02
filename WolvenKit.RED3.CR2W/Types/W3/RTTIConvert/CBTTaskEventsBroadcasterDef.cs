using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskEventsBroadcasterDef : IBehTreeReactionTaskDefinition
	{
		[Ordinal(1)] [RED("broadcastedEvents", 2,0)] 		public CArray<SReactionEventData> BroadcastedEvents { get; set;}

		[Ordinal(2)] [RED("rescanInterval")] 		public CFloat RescanInterval { get; set;}

		[Ordinal(3)] [RED("minIntervalBetweenScenes")] 		public CFloat MinIntervalBetweenScenes { get; set;}

		public CBTTaskEventsBroadcasterDef(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskEventsBroadcasterDef(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}