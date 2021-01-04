using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class gameEffectObjectProvider_QuerySphere : gameEffectObjectProvider
	{
		[Ordinal(0)]  [RED("filterData")] public CHandle<physicsFilterData> FilterData { get; set; }
		[Ordinal(1)]  [RED("gatherOnlyPuppets")] public CBool GatherOnlyPuppets { get; set; }

		public gameEffectObjectProvider_QuerySphere(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
