using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class VendingMachineDeviceBlackboardDef : DeviceBaseBlackboardDef
	{
		private gamebbScriptID_Variant _actionStatus;
		private gamebbScriptID_Bool _soldOut;

		[Ordinal(7)] 
		[RED("ActionStatus")] 
		public gamebbScriptID_Variant ActionStatus
		{
			get => GetProperty(ref _actionStatus);
			set => SetProperty(ref _actionStatus, value);
		}

		[Ordinal(8)] 
		[RED("SoldOut")] 
		public gamebbScriptID_Bool SoldOut
		{
			get => GetProperty(ref _soldOut);
			set => SetProperty(ref _soldOut, value);
		}

		public VendingMachineDeviceBlackboardDef(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
