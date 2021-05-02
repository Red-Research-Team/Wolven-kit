using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SBehaviorConstraintNodeFloorIKCommonData : CVariable
	{
		[Ordinal(1)] [RED("gravityCentreBone")] 		public CName GravityCentreBone { get; set;}

		[Ordinal(2)] [RED("rootRotationBlendTime")] 		public CFloat RootRotationBlendTime { get; set;}

		[Ordinal(3)] [RED("verticalVelocityOffsetUpBlendTime")] 		public CFloat VerticalVelocityOffsetUpBlendTime { get; set;}

		[Ordinal(4)] [RED("verticalVelocityOffsetDownBlendTime")] 		public CFloat VerticalVelocityOffsetDownBlendTime { get; set;}

		[Ordinal(5)] [RED("slidingOnSlopeBlendTime")] 		public CFloat SlidingOnSlopeBlendTime { get; set;}

		public SBehaviorConstraintNodeFloorIKCommonData(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SBehaviorConstraintNodeFloorIKCommonData(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}