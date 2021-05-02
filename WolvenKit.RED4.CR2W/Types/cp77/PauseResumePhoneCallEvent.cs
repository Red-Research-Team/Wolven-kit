using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class PauseResumePhoneCallEvent : redEvent
	{
		private CFloat _callDuration;
		private CBool _pauseCall;
		private CEnum<gamedataStatPoolType> _statPoolType;

		[Ordinal(0)] 
		[RED("callDuration")] 
		public CFloat CallDuration
		{
			get => GetProperty(ref _callDuration);
			set => SetProperty(ref _callDuration, value);
		}

		[Ordinal(1)] 
		[RED("pauseCall")] 
		public CBool PauseCall
		{
			get => GetProperty(ref _pauseCall);
			set => SetProperty(ref _pauseCall, value);
		}

		[Ordinal(2)] 
		[RED("statPoolType")] 
		public CEnum<gamedataStatPoolType> StatPoolType
		{
			get => GetProperty(ref _statPoolType);
			set => SetProperty(ref _statPoolType, value);
		}

		public PauseResumePhoneCallEvent(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
