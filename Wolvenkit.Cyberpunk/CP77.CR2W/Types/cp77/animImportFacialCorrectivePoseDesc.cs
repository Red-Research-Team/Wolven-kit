using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class animImportFacialCorrectivePoseDesc : CVariable
	{
		[Ordinal(0)]  [RED("inBetweenScopeMultipliers")] public CArray<CFloat> InBetweenScopeMultipliers { get; set; }
		[Ordinal(1)]  [RED("index")] public CUInt16 Index { get; set; }
		[Ordinal(2)]  [RED("influenceMainWeightIndices")] public CArray<CUInt16> InfluenceMainWeightIndices { get; set; }
		[Ordinal(3)]  [RED("influencedBy")] public CArray<CName> InfluencedBy { get; set; }
		[Ordinal(4)]  [RED("influencedBySpeed")] public CUInt8 InfluencedBySpeed { get; set; }
		[Ordinal(5)]  [RED("linearCorrection")] public CBool LinearCorrection { get; set; }
		[Ordinal(6)]  [RED("name")] public CName Name { get; set; }
		[Ordinal(7)]  [RED("parentIndices")] public CArray<CUInt16> ParentIndices { get; set; }
		[Ordinal(8)]  [RED("parentsInBetweenIndices")] public CArray<CInt16> ParentsInBetweenIndices { get; set; }
		[Ordinal(9)]  [RED("poseLOD")] public CUInt8 PoseLOD { get; set; }
		[Ordinal(10)]  [RED("poseType")] public CUInt8 PoseType { get; set; }
		[Ordinal(11)]  [RED("poses")] public CArray<animImportFacialCorrectivePoseDataDesc> Poses { get; set; }
		[Ordinal(12)]  [RED("useGlobalWeight")] public CBool UseGlobalWeight { get; set; }
		[Ordinal(13)]  [RED("weights")] public CArray<CFloat> Weights { get; set; }

		public animImportFacialCorrectivePoseDesc(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
