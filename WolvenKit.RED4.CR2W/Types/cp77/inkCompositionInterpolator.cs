using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class inkCompositionInterpolator : CVariable
	{
		private CName _parameter;
		private CEnum<inkanimInterpolationMode> _interpolationMode;
		private CEnum<inkanimInterpolationType> _interpolationType;
		private CFloat _duration;
		private CFloat _startDelay;

		[Ordinal(0)] 
		[RED("parameter")] 
		public CName Parameter
		{
			get => GetProperty(ref _parameter);
			set => SetProperty(ref _parameter, value);
		}

		[Ordinal(1)] 
		[RED("interpolationMode")] 
		public CEnum<inkanimInterpolationMode> InterpolationMode
		{
			get => GetProperty(ref _interpolationMode);
			set => SetProperty(ref _interpolationMode, value);
		}

		[Ordinal(2)] 
		[RED("interpolationType")] 
		public CEnum<inkanimInterpolationType> InterpolationType
		{
			get => GetProperty(ref _interpolationType);
			set => SetProperty(ref _interpolationType, value);
		}

		[Ordinal(3)] 
		[RED("duration")] 
		public CFloat Duration
		{
			get => GetProperty(ref _duration);
			set => SetProperty(ref _duration, value);
		}

		[Ordinal(4)] 
		[RED("startDelay")] 
		public CFloat StartDelay
		{
			get => GetProperty(ref _startDelay);
			set => SetProperty(ref _startDelay, value);
		}

		public inkCompositionInterpolator(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
