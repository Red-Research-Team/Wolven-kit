using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class AnimFeature_PlayerCoverActionWeaponHolster : animAnimFeature
	{
		private CBool _isWeaponHolstered;

		[Ordinal(0)] 
		[RED("isWeaponHolstered")] 
		public CBool IsWeaponHolstered
		{
			get => GetProperty(ref _isWeaponHolstered);
			set => SetProperty(ref _isWeaponHolstered, value);
		}

		public AnimFeature_PlayerCoverActionWeaponHolster(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
