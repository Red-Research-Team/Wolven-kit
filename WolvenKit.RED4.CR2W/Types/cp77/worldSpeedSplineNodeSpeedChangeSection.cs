using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class worldSpeedSplineNodeSpeedChangeSection : CVariable
	{
		private CFloat _start;
		private CFloat _end;
		private CFloat _targetSpeed_M_P_S;

		[Ordinal(0)] 
		[RED("start")] 
		public CFloat Start
		{
			get => GetProperty(ref _start);
			set => SetProperty(ref _start, value);
		}

		[Ordinal(1)] 
		[RED("end")] 
		public CFloat End
		{
			get => GetProperty(ref _end);
			set => SetProperty(ref _end, value);
		}

		[Ordinal(2)] 
		[RED("targetSpeed_M_P_S")] 
		public CFloat TargetSpeed_M_P_S
		{
			get => GetProperty(ref _targetSpeed_M_P_S);
			set => SetProperty(ref _targetSpeed_M_P_S, value);
		}

		public worldSpeedSplineNodeSpeedChangeSection(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
