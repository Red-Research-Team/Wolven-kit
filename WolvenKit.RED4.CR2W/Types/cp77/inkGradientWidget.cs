using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class inkGradientWidget : inkBaseShapeWidget
	{
		private CEnum<inkGradientMode> _gradientMode;
		private HDRColor _startColor;
		private HDRColor _endColor;
		private CFloat _angle;

		[Ordinal(20)] 
		[RED("gradientMode")] 
		public CEnum<inkGradientMode> GradientMode
		{
			get => GetProperty(ref _gradientMode);
			set => SetProperty(ref _gradientMode, value);
		}

		[Ordinal(21)] 
		[RED("startColor")] 
		public HDRColor StartColor
		{
			get => GetProperty(ref _startColor);
			set => SetProperty(ref _startColor, value);
		}

		[Ordinal(22)] 
		[RED("endColor")] 
		public HDRColor EndColor
		{
			get => GetProperty(ref _endColor);
			set => SetProperty(ref _endColor, value);
		}

		[Ordinal(23)] 
		[RED("angle")] 
		public CFloat Angle
		{
			get => GetProperty(ref _angle);
			set => SetProperty(ref _angle, value);
		}

		public inkGradientWidget(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
