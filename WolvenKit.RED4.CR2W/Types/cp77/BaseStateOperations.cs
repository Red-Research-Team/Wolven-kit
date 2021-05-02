using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class BaseStateOperations : DeviceOperations
	{
		private SGenericDeviceActionsData _stateActionsOverrides;
		private CArray<SBaseStateOperationData> _baseStateOperations;
		private CBool _wasStateCached;
		private CEnum<EDeviceStatus> _cachedState;

		[Ordinal(2)] 
		[RED("stateActionsOverrides")] 
		public SGenericDeviceActionsData StateActionsOverrides
		{
			get => GetProperty(ref _stateActionsOverrides);
			set => SetProperty(ref _stateActionsOverrides, value);
		}

		[Ordinal(3)] 
		[RED("baseStateOperations")] 
		public CArray<SBaseStateOperationData> BaseStateOperations_
		{
			get => GetProperty(ref _baseStateOperations);
			set => SetProperty(ref _baseStateOperations, value);
		}

		[Ordinal(4)] 
		[RED("wasStateCached")] 
		public CBool WasStateCached
		{
			get => GetProperty(ref _wasStateCached);
			set => SetProperty(ref _wasStateCached, value);
		}

		[Ordinal(5)] 
		[RED("cachedState")] 
		public CEnum<EDeviceStatus> CachedState
		{
			get => GetProperty(ref _cachedState);
			set => SetProperty(ref _cachedState, value);
		}

		public BaseStateOperations(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
