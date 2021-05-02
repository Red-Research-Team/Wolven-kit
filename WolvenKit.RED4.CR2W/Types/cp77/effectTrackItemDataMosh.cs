using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class effectTrackItemDataMosh : effectTrackItem
	{
		private CBool _override;
		private effectEffectParameterEvaluatorFloat _intensity;
		private CBool _useGlitch;
		private effectEffectParameterEvaluatorVector _glitchColor;

		[Ordinal(3)] 
		[RED("override")] 
		public CBool Override
		{
			get => GetProperty(ref _override);
			set => SetProperty(ref _override, value);
		}

		[Ordinal(4)] 
		[RED("intensity")] 
		public effectEffectParameterEvaluatorFloat Intensity
		{
			get => GetProperty(ref _intensity);
			set => SetProperty(ref _intensity, value);
		}

		[Ordinal(5)] 
		[RED("useGlitch")] 
		public CBool UseGlitch
		{
			get => GetProperty(ref _useGlitch);
			set => SetProperty(ref _useGlitch, value);
		}

		[Ordinal(6)] 
		[RED("glitchColor")] 
		public effectEffectParameterEvaluatorVector GlitchColor
		{
			get => GetProperty(ref _glitchColor);
			set => SetProperty(ref _glitchColor, value);
		}

		public effectTrackItemDataMosh(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
