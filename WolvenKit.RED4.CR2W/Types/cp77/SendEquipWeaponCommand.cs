using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class SendEquipWeaponCommand : AIbehaviortaskScript
	{
		private CBool _secondary;

		[Ordinal(0)] 
		[RED("secondary")] 
		public CBool Secondary
		{
			get => GetProperty(ref _secondary);
			set => SetProperty(ref _secondary, value);
		}

		public SendEquipWeaponCommand(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
