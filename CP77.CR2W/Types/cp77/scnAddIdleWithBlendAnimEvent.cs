using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class scnAddIdleWithBlendAnimEvent : scnSceneEvent
	{
		[Ordinal(0)]  [RED("performerId")] public scnPerformerId PerformerId { get; set; }
		[Ordinal(1)]  [RED("actorComponent")] public CName ActorComponent { get; set; }
		[Ordinal(2)]  [RED("targetWeight")] public CFloat TargetWeight { get; set; }

		public scnAddIdleWithBlendAnimEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
