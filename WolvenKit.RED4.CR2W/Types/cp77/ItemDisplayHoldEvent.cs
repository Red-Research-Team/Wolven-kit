using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class ItemDisplayHoldEvent : redEvent
	{
		private InventoryItemData _itemData;
		private CHandle<inkActionName> _actionName;

		[Ordinal(0)] 
		[RED("itemData")] 
		public InventoryItemData ItemData
		{
			get => GetProperty(ref _itemData);
			set => SetProperty(ref _itemData, value);
		}

		[Ordinal(1)] 
		[RED("actionName")] 
		public CHandle<inkActionName> ActionName
		{
			get => GetProperty(ref _actionName);
			set => SetProperty(ref _actionName, value);
		}

		public ItemDisplayHoldEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
