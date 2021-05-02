using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimNode_FloatValueDebugProvider : CVariable
	{
		private CBool _isEnabled;
		private CFloat _min;
		private CFloat _max;
		private CFloat _progress;
		private CBool _auto;
		private CFloat _speed;
		private CBool _wrap;

		[Ordinal(0)] 
		[RED("isEnabled")] 
		public CBool IsEnabled
		{
			get => GetProperty(ref _isEnabled);
			set => SetProperty(ref _isEnabled, value);
		}

		[Ordinal(1)] 
		[RED("min")] 
		public CFloat Min
		{
			get => GetProperty(ref _min);
			set => SetProperty(ref _min, value);
		}

		[Ordinal(2)] 
		[RED("max")] 
		public CFloat Max
		{
			get => GetProperty(ref _max);
			set => SetProperty(ref _max, value);
		}

		[Ordinal(3)] 
		[RED("progress")] 
		public CFloat Progress
		{
			get => GetProperty(ref _progress);
			set => SetProperty(ref _progress, value);
		}

		[Ordinal(4)] 
		[RED("auto")] 
		public CBool Auto
		{
			get => GetProperty(ref _auto);
			set => SetProperty(ref _auto, value);
		}

		[Ordinal(5)] 
		[RED("speed")] 
		public CFloat Speed
		{
			get => GetProperty(ref _speed);
			set => SetProperty(ref _speed, value);
		}

		[Ordinal(6)] 
		[RED("wrap")] 
		public CBool Wrap
		{
			get => GetProperty(ref _wrap);
			set => SetProperty(ref _wrap, value);
		}

		public animAnimNode_FloatValueDebugProvider(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
