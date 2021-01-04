using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class gameSmartObjectPoint : CVariable
	{
		[Ordinal(0)]  [RED("isReachable")] public CBool IsReachable { get; set; }

		public gameSmartObjectPoint(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
