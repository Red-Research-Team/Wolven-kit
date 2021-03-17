using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animSBehaviorConstraintNodeFloorIKVerticalBoneData : CVariable
	{
		private animTransformIndex _bone;
		private CFloat _min_offset;
		private CFloat _max_offset;
		private CFloat _offsetToDesiredBlendTime;
		private CFloat _verticalOffsetBlendTime;
		private CFloat _stiffness;

		[Ordinal(0)] 
		[RED("bone")] 
		public animTransformIndex Bone
		{
			get => GetProperty(ref _bone);
			set => SetProperty(ref _bone, value);
		}

		[Ordinal(1)] 
		[RED("Min offset")] 
		public CFloat Min_offset
		{
			get => GetProperty(ref _min_offset);
			set => SetProperty(ref _min_offset, value);
		}

		[Ordinal(2)] 
		[RED("Max offset")] 
		public CFloat Max_offset
		{
			get => GetProperty(ref _max_offset);
			set => SetProperty(ref _max_offset, value);
		}

		[Ordinal(3)] 
		[RED("offsetToDesiredBlendTime")] 
		public CFloat OffsetToDesiredBlendTime
		{
			get => GetProperty(ref _offsetToDesiredBlendTime);
			set => SetProperty(ref _offsetToDesiredBlendTime, value);
		}

		[Ordinal(4)] 
		[RED("verticalOffsetBlendTime")] 
		public CFloat VerticalOffsetBlendTime
		{
			get => GetProperty(ref _verticalOffsetBlendTime);
			set => SetProperty(ref _verticalOffsetBlendTime, value);
		}

		[Ordinal(5)] 
		[RED("stiffness")] 
		public CFloat Stiffness
		{
			get => GetProperty(ref _stiffness);
			set => SetProperty(ref _stiffness, value);
		}

		public animSBehaviorConstraintNodeFloorIKVerticalBoneData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
