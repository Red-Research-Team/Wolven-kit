using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class TimeDilationParameters : IScriptable
	{
		private CName _reason;
		private CFloat _timeDilation;
		private CFloat _playerTimeDilation;
		private CFloat _duration;
		private CName _easeInCurve;
		private CName _easeOutCurve;

		[Ordinal(0)] 
		[RED("reason")] 
		public CName Reason
		{
			get => GetProperty(ref _reason);
			set => SetProperty(ref _reason, value);
		}

		[Ordinal(1)] 
		[RED("timeDilation")] 
		public CFloat TimeDilation
		{
			get => GetProperty(ref _timeDilation);
			set => SetProperty(ref _timeDilation, value);
		}

		[Ordinal(2)] 
		[RED("playerTimeDilation")] 
		public CFloat PlayerTimeDilation
		{
			get => GetProperty(ref _playerTimeDilation);
			set => SetProperty(ref _playerTimeDilation, value);
		}

		[Ordinal(3)] 
		[RED("duration")] 
		public CFloat Duration
		{
			get => GetProperty(ref _duration);
			set => SetProperty(ref _duration, value);
		}

		[Ordinal(4)] 
		[RED("easeInCurve")] 
		public CName EaseInCurve
		{
			get => GetProperty(ref _easeInCurve);
			set => SetProperty(ref _easeInCurve, value);
		}

		[Ordinal(5)] 
		[RED("easeOutCurve")] 
		public CName EaseOutCurve
		{
			get => GetProperty(ref _easeOutCurve);
			set => SetProperty(ref _easeOutCurve, value);
		}

		public TimeDilationParameters(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
