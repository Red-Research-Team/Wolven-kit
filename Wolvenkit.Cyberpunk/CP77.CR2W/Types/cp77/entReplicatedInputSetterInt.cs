using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class entReplicatedInputSetterInt : entReplicatedInputSetterBase
	{
		[Ordinal(0)]  [RED("value")] public CInt32 Value { get; set; }

		public entReplicatedInputSetterInt(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
