using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class GameplayEquipRequest : gamePlayerScriptableSystemRequest
	{
		private gameItemID _itemID;
		private CInt32 _slotIndex;
		private CBool _addToInventory;
		private CBool _equipToCurrentActiveSlot;
		private CBool _blockUpdateWeaponActiveSlots;
		private CBool _forceEquipWeapon;

		[Ordinal(1)] 
		[RED("itemID")] 
		public gameItemID ItemID
		{
			get => GetProperty(ref _itemID);
			set => SetProperty(ref _itemID, value);
		}

		[Ordinal(2)] 
		[RED("slotIndex")] 
		public CInt32 SlotIndex
		{
			get => GetProperty(ref _slotIndex);
			set => SetProperty(ref _slotIndex, value);
		}

		[Ordinal(3)] 
		[RED("addToInventory")] 
		public CBool AddToInventory
		{
			get => GetProperty(ref _addToInventory);
			set => SetProperty(ref _addToInventory, value);
		}

		[Ordinal(4)] 
		[RED("equipToCurrentActiveSlot")] 
		public CBool EquipToCurrentActiveSlot
		{
			get => GetProperty(ref _equipToCurrentActiveSlot);
			set => SetProperty(ref _equipToCurrentActiveSlot, value);
		}

		[Ordinal(5)] 
		[RED("blockUpdateWeaponActiveSlots")] 
		public CBool BlockUpdateWeaponActiveSlots
		{
			get => GetProperty(ref _blockUpdateWeaponActiveSlots);
			set => SetProperty(ref _blockUpdateWeaponActiveSlots, value);
		}

		[Ordinal(6)] 
		[RED("forceEquipWeapon")] 
		public CBool ForceEquipWeapon
		{
			get => GetProperty(ref _forceEquipWeapon);
			set => SetProperty(ref _forceEquipWeapon, value);
		}

		public GameplayEquipRequest(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
