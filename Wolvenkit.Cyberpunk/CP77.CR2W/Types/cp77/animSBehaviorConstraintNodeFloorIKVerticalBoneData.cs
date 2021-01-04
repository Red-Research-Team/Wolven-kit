using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class animSBehaviorConstraintNodeFloorIKVerticalBoneData : CVariable
	{
		[Ordinal(0)]  [RED("Max offset")] public CFloat MaxOffset { get; set; }
		[Ordinal(1)]  [RED("Min offset")] public CFloat MinOffset { get; set; }
		[Ordinal(2)]  [RED("bone")] public animTransformIndex Bone { get; set; }
		[Ordinal(3)]  [RED("offsetToDesiredBlendTime")] public CFloat OffsetToDesiredBlendTime { get; set; }
		[Ordinal(4)]  [RED("stiffness")] public CFloat Stiffness { get; set; }
		[Ordinal(5)]  [RED("verticalOffsetBlendTime")] public CFloat VerticalOffsetBlendTime { get; set; }

		public animSBehaviorConstraintNodeFloorIKVerticalBoneData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
