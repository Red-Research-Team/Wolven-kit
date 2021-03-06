using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class LiftSetMovementStateEvent : redEvent
	{
		private CEnum<gamePlatformMovementState> _movementState;

		[Ordinal(0)] 
		[RED("movementState")] 
		public CEnum<gamePlatformMovementState> MovementState
		{
			get => GetProperty(ref _movementState);
			set => SetProperty(ref _movementState, value);
		}

		public LiftSetMovementStateEvent(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
