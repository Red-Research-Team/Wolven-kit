using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class AICoverDataDef : AIBlackboardDef
	{
		private gamebbScriptID_CName _exposureMethod;
		private gamebbScriptID_Bool _currentlyExposed;
		private gamebbScriptID_Variant _commandExposureMethods;
		private gamebbScriptID_Bool _commandCoverOverride;
		private gamebbScriptID_CName _currentCoverStance;
		private gamebbScriptID_CName _desiredCoverStance;
		private gamebbScriptID_CName _lastCoverPreset;
		private gamebbScriptID_CName _lastInitialCoverPreset;
		private gamebbScriptID_Float _lastCoverChangeThreshold;
		private gamebbScriptID_Float _lastVisibilityCheckTimestamp;
		private gamebbScriptID_Variant _currentRing;
		private gamebbScriptID_Variant _lastCoverRing;
		private gamebbScriptID_Int32 _lastDebugCoverPreset;
		private gamebbScriptID_Bool _firstCoverEvaluationDone;

		[Ordinal(0)] 
		[RED("exposureMethod")] 
		public gamebbScriptID_CName ExposureMethod
		{
			get => GetProperty(ref _exposureMethod);
			set => SetProperty(ref _exposureMethod, value);
		}

		[Ordinal(1)] 
		[RED("currentlyExposed")] 
		public gamebbScriptID_Bool CurrentlyExposed
		{
			get => GetProperty(ref _currentlyExposed);
			set => SetProperty(ref _currentlyExposed, value);
		}

		[Ordinal(2)] 
		[RED("commandExposureMethods")] 
		public gamebbScriptID_Variant CommandExposureMethods
		{
			get => GetProperty(ref _commandExposureMethods);
			set => SetProperty(ref _commandExposureMethods, value);
		}

		[Ordinal(3)] 
		[RED("commandCoverOverride")] 
		public gamebbScriptID_Bool CommandCoverOverride
		{
			get => GetProperty(ref _commandCoverOverride);
			set => SetProperty(ref _commandCoverOverride, value);
		}

		[Ordinal(4)] 
		[RED("currentCoverStance")] 
		public gamebbScriptID_CName CurrentCoverStance
		{
			get => GetProperty(ref _currentCoverStance);
			set => SetProperty(ref _currentCoverStance, value);
		}

		[Ordinal(5)] 
		[RED("desiredCoverStance")] 
		public gamebbScriptID_CName DesiredCoverStance
		{
			get => GetProperty(ref _desiredCoverStance);
			set => SetProperty(ref _desiredCoverStance, value);
		}

		[Ordinal(6)] 
		[RED("lastCoverPreset")] 
		public gamebbScriptID_CName LastCoverPreset
		{
			get => GetProperty(ref _lastCoverPreset);
			set => SetProperty(ref _lastCoverPreset, value);
		}

		[Ordinal(7)] 
		[RED("lastInitialCoverPreset")] 
		public gamebbScriptID_CName LastInitialCoverPreset
		{
			get => GetProperty(ref _lastInitialCoverPreset);
			set => SetProperty(ref _lastInitialCoverPreset, value);
		}

		[Ordinal(8)] 
		[RED("lastCoverChangeThreshold")] 
		public gamebbScriptID_Float LastCoverChangeThreshold
		{
			get => GetProperty(ref _lastCoverChangeThreshold);
			set => SetProperty(ref _lastCoverChangeThreshold, value);
		}

		[Ordinal(9)] 
		[RED("lastVisibilityCheckTimestamp")] 
		public gamebbScriptID_Float LastVisibilityCheckTimestamp
		{
			get => GetProperty(ref _lastVisibilityCheckTimestamp);
			set => SetProperty(ref _lastVisibilityCheckTimestamp, value);
		}

		[Ordinal(10)] 
		[RED("currentRing")] 
		public gamebbScriptID_Variant CurrentRing
		{
			get => GetProperty(ref _currentRing);
			set => SetProperty(ref _currentRing, value);
		}

		[Ordinal(11)] 
		[RED("lastCoverRing")] 
		public gamebbScriptID_Variant LastCoverRing
		{
			get => GetProperty(ref _lastCoverRing);
			set => SetProperty(ref _lastCoverRing, value);
		}

		[Ordinal(12)] 
		[RED("lastDebugCoverPreset")] 
		public gamebbScriptID_Int32 LastDebugCoverPreset
		{
			get => GetProperty(ref _lastDebugCoverPreset);
			set => SetProperty(ref _lastDebugCoverPreset, value);
		}

		[Ordinal(13)] 
		[RED("firstCoverEvaluationDone")] 
		public gamebbScriptID_Bool FirstCoverEvaluationDone
		{
			get => GetProperty(ref _firstCoverEvaluationDone);
			set => SetProperty(ref _firstCoverEvaluationDone, value);
		}

		public AICoverDataDef(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
