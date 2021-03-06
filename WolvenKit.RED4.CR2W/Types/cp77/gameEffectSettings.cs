using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameEffectSettings : CVariable
	{
		private CBool _advancedTargetHandling;
		private CBool _synchronousProcessingForPlayer;
		private CBool _forceSynchronousProcessing;
		private CBool _tempExecuteOnlyOnce;
		private CFloat _tickRate;
		private CBool _useSimTimeForTick;

		[Ordinal(0)] 
		[RED("advancedTargetHandling")] 
		public CBool AdvancedTargetHandling
		{
			get => GetProperty(ref _advancedTargetHandling);
			set => SetProperty(ref _advancedTargetHandling, value);
		}

		[Ordinal(1)] 
		[RED("synchronousProcessingForPlayer")] 
		public CBool SynchronousProcessingForPlayer
		{
			get => GetProperty(ref _synchronousProcessingForPlayer);
			set => SetProperty(ref _synchronousProcessingForPlayer, value);
		}

		[Ordinal(2)] 
		[RED("forceSynchronousProcessing")] 
		public CBool ForceSynchronousProcessing
		{
			get => GetProperty(ref _forceSynchronousProcessing);
			set => SetProperty(ref _forceSynchronousProcessing, value);
		}

		[Ordinal(3)] 
		[RED("tempExecuteOnlyOnce")] 
		public CBool TempExecuteOnlyOnce
		{
			get => GetProperty(ref _tempExecuteOnlyOnce);
			set => SetProperty(ref _tempExecuteOnlyOnce, value);
		}

		[Ordinal(4)] 
		[RED("tickRate")] 
		public CFloat TickRate
		{
			get => GetProperty(ref _tickRate);
			set => SetProperty(ref _tickRate, value);
		}

		[Ordinal(5)] 
		[RED("useSimTimeForTick")] 
		public CBool UseSimTimeForTick
		{
			get => GetProperty(ref _useSimTimeForTick);
			set => SetProperty(ref _useSimTimeForTick, value);
		}

		public gameEffectSettings(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
