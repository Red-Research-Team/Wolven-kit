using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameRegular1v1FinisherScenario : gameIFinisherScenario
	{
		private raRef<workWorkspotResource> _attackerWorkspot;
		private raRef<workWorkspotResource> _targetWorkspot;
		private CName _syncAnimSlotName;
		private CFloat _targetPlaybackDelay;
		private CFloat _targetBlendTime;
		private CFloat _attackerPlaybackDelay;
		private CFloat _attackerBlendTime;
		private CEnum<gameRegular1v1FinisherScenarioPivotSetting> _pivotSettings;
		private CBool _attackerIsMaster;

		[Ordinal(0)] 
		[RED("attackerWorkspot")] 
		public raRef<workWorkspotResource> AttackerWorkspot
		{
			get => GetProperty(ref _attackerWorkspot);
			set => SetProperty(ref _attackerWorkspot, value);
		}

		[Ordinal(1)] 
		[RED("targetWorkspot")] 
		public raRef<workWorkspotResource> TargetWorkspot
		{
			get => GetProperty(ref _targetWorkspot);
			set => SetProperty(ref _targetWorkspot, value);
		}

		[Ordinal(2)] 
		[RED("syncAnimSlotName")] 
		public CName SyncAnimSlotName
		{
			get => GetProperty(ref _syncAnimSlotName);
			set => SetProperty(ref _syncAnimSlotName, value);
		}

		[Ordinal(3)] 
		[RED("targetPlaybackDelay")] 
		public CFloat TargetPlaybackDelay
		{
			get => GetProperty(ref _targetPlaybackDelay);
			set => SetProperty(ref _targetPlaybackDelay, value);
		}

		[Ordinal(4)] 
		[RED("targetBlendTime")] 
		public CFloat TargetBlendTime
		{
			get => GetProperty(ref _targetBlendTime);
			set => SetProperty(ref _targetBlendTime, value);
		}

		[Ordinal(5)] 
		[RED("attackerPlaybackDelay")] 
		public CFloat AttackerPlaybackDelay
		{
			get => GetProperty(ref _attackerPlaybackDelay);
			set => SetProperty(ref _attackerPlaybackDelay, value);
		}

		[Ordinal(6)] 
		[RED("attackerBlendTime")] 
		public CFloat AttackerBlendTime
		{
			get => GetProperty(ref _attackerBlendTime);
			set => SetProperty(ref _attackerBlendTime, value);
		}

		[Ordinal(7)] 
		[RED("pivotSettings")] 
		public CEnum<gameRegular1v1FinisherScenarioPivotSetting> PivotSettings
		{
			get => GetProperty(ref _pivotSettings);
			set => SetProperty(ref _pivotSettings, value);
		}

		[Ordinal(8)] 
		[RED("attackerIsMaster")] 
		public CBool AttackerIsMaster
		{
			get => GetProperty(ref _attackerIsMaster);
			set => SetProperty(ref _attackerIsMaster, value);
		}

		public gameRegular1v1FinisherScenario(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
