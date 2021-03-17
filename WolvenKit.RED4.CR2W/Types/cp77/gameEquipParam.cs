using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameEquipParam : CVariable
	{
		private TweakDBID _slotID;
		private gameItemID _itemIDToEquip;
		private CBool _forceFirstEquip;
		private CBool _instant;

		[Ordinal(0)] 
		[RED("slotID")] 
		public TweakDBID SlotID
		{
			get => GetProperty(ref _slotID);
			set => SetProperty(ref _slotID, value);
		}

		[Ordinal(1)] 
		[RED("itemIDToEquip")] 
		public gameItemID ItemIDToEquip
		{
			get => GetProperty(ref _itemIDToEquip);
			set => SetProperty(ref _itemIDToEquip, value);
		}

		[Ordinal(2)] 
		[RED("forceFirstEquip")] 
		public CBool ForceFirstEquip
		{
			get => GetProperty(ref _forceFirstEquip);
			set => SetProperty(ref _forceFirstEquip, value);
		}

		[Ordinal(3)] 
		[RED("instant")] 
		public CBool Instant
		{
			get => GetProperty(ref _instant);
			set => SetProperty(ref _instant, value);
		}

		public gameEquipParam(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
