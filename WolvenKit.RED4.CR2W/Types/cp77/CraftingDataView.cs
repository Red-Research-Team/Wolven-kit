using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class CraftingDataView : inkScriptableDataViewWrapper
	{
		private CEnum<ItemFilterCategory> _itemFilterType;
		private CEnum<ItemSortMode> _itemSortMode;
		private CArray<CEnum<gamedataItemType>> _attachmentsList;
		private wCHandle<UIScriptableSystem> _uiScriptableSystem;

		[Ordinal(0)] 
		[RED("itemFilterType")] 
		public CEnum<ItemFilterCategory> ItemFilterType
		{
			get
			{
				if (_itemFilterType == null)
				{
					_itemFilterType = (CEnum<ItemFilterCategory>) CR2WTypeManager.Create("ItemFilterCategory", "itemFilterType", cr2w, this);
				}
				return _itemFilterType;
			}
			set
			{
				if (_itemFilterType == value)
				{
					return;
				}
				_itemFilterType = value;
				PropertySet(this);
			}
		}

		[Ordinal(1)] 
		[RED("itemSortMode")] 
		public CEnum<ItemSortMode> ItemSortMode
		{
			get
			{
				if (_itemSortMode == null)
				{
					_itemSortMode = (CEnum<ItemSortMode>) CR2WTypeManager.Create("ItemSortMode", "itemSortMode", cr2w, this);
				}
				return _itemSortMode;
			}
			set
			{
				if (_itemSortMode == value)
				{
					return;
				}
				_itemSortMode = value;
				PropertySet(this);
			}
		}

		[Ordinal(2)] 
		[RED("attachmentsList")] 
		public CArray<CEnum<gamedataItemType>> AttachmentsList
		{
			get
			{
				if (_attachmentsList == null)
				{
					_attachmentsList = (CArray<CEnum<gamedataItemType>>) CR2WTypeManager.Create("array:gamedataItemType", "attachmentsList", cr2w, this);
				}
				return _attachmentsList;
			}
			set
			{
				if (_attachmentsList == value)
				{
					return;
				}
				_attachmentsList = value;
				PropertySet(this);
			}
		}

		[Ordinal(3)] 
		[RED("uiScriptableSystem")] 
		public wCHandle<UIScriptableSystem> UiScriptableSystem
		{
			get
			{
				if (_uiScriptableSystem == null)
				{
					_uiScriptableSystem = (wCHandle<UIScriptableSystem>) CR2WTypeManager.Create("whandle:UIScriptableSystem", "uiScriptableSystem", cr2w, this);
				}
				return _uiScriptableSystem;
			}
			set
			{
				if (_uiScriptableSystem == value)
				{
					return;
				}
				_uiScriptableSystem = value;
				PropertySet(this);
			}
		}

		public CraftingDataView(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
