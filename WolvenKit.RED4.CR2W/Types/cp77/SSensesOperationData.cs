using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class SSensesOperationData : CVariable
	{
		private CBool _isActivatorPlayer;
		private CBool _isActivatorNPC;
		private CName _attitudeGroup;
		private CEnum<ETriggerOperationType> _operationType;
		private SBaseDeviceOperationData _operation;

		[Ordinal(0)] 
		[RED("isActivatorPlayer")] 
		public CBool IsActivatorPlayer
		{
			get => GetProperty(ref _isActivatorPlayer);
			set => SetProperty(ref _isActivatorPlayer, value);
		}

		[Ordinal(1)] 
		[RED("isActivatorNPC")] 
		public CBool IsActivatorNPC
		{
			get => GetProperty(ref _isActivatorNPC);
			set => SetProperty(ref _isActivatorNPC, value);
		}

		[Ordinal(2)] 
		[RED("attitudeGroup")] 
		public CName AttitudeGroup
		{
			get => GetProperty(ref _attitudeGroup);
			set => SetProperty(ref _attitudeGroup, value);
		}

		[Ordinal(3)] 
		[RED("operationType")] 
		public CEnum<ETriggerOperationType> OperationType
		{
			get => GetProperty(ref _operationType);
			set => SetProperty(ref _operationType, value);
		}

		[Ordinal(4)] 
		[RED("operation")] 
		public SBaseDeviceOperationData Operation
		{
			get => GetProperty(ref _operation);
			set => SetProperty(ref _operation, value);
		}

		public SSensesOperationData(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
