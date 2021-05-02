using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class vehicleVehicleSlotsState : ISerializable
	{
		private CEnum<vehicleVehicleDoorState> _vehicleDoorState;
		private CEnum<vehicleEVehicleWindowState> _vehicleWindowState;
		private CEnum<vehicleVehicleDoorInteractionState> _vehicleInteractionState;

		[Ordinal(0)] 
		[RED("vehicleDoorState")] 
		public CEnum<vehicleVehicleDoorState> VehicleDoorState
		{
			get => GetProperty(ref _vehicleDoorState);
			set => SetProperty(ref _vehicleDoorState, value);
		}

		[Ordinal(1)] 
		[RED("vehicleWindowState")] 
		public CEnum<vehicleEVehicleWindowState> VehicleWindowState
		{
			get => GetProperty(ref _vehicleWindowState);
			set => SetProperty(ref _vehicleWindowState, value);
		}

		[Ordinal(2)] 
		[RED("vehicleInteractionState")] 
		public CEnum<vehicleVehicleDoorInteractionState> VehicleInteractionState
		{
			get => GetProperty(ref _vehicleInteractionState);
			set => SetProperty(ref _vehicleInteractionState, value);
		}

		public vehicleVehicleSlotsState(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
