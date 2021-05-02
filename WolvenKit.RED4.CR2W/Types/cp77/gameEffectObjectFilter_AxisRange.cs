using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameEffectObjectFilter_AxisRange : gameEffectObjectSingleFilter
	{
		private CEnum<gameEffectObjectFilter_AxisRangeAxis> _axis;
		private gameEffectInputParameter_Vector _position;
		private gameEffectInputParameter_Vector _constraints;

		[Ordinal(0)] 
		[RED("axis")] 
		public CEnum<gameEffectObjectFilter_AxisRangeAxis> Axis
		{
			get => GetProperty(ref _axis);
			set => SetProperty(ref _axis, value);
		}

		[Ordinal(1)] 
		[RED("position")] 
		public gameEffectInputParameter_Vector Position
		{
			get => GetProperty(ref _position);
			set => SetProperty(ref _position, value);
		}

		[Ordinal(2)] 
		[RED("constraints")] 
		public gameEffectInputParameter_Vector Constraints
		{
			get => GetProperty(ref _constraints);
			set => SetProperty(ref _constraints, value);
		}

		public gameEffectObjectFilter_AxisRange(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
