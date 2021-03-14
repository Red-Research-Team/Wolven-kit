using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class VendorConfirmationPopup : gameuiWidgetGameController
	{
		private inkTextWidgetReference _itemNameText;
		private inkWidgetReference _buttonHintsRoot;
		private inkWidgetReference _itemDisplayRef;
		private inkWidgetReference _rairtyBar;
		private inkWidgetReference _eqippedItemContainer;
		private inkWidgetReference _itemPriceContainer;
		private inkTextWidgetReference _itemPriceText;
		private inkWidgetReference _root;
		private inkWidgetReference _background;
		private CHandle<VendorConfirmationPopupCloseData> _closeData;
		private wCHandle<ButtonHints> _buttonHintsController;
		private CHandle<gameItemData> _gameData;
		private inkWidgetReference _buttonOk;
		private inkWidgetReference _buttonCancel;
		private CHandle<VendorConfirmationPopupData> _data;
		private CHandle<InventoryItemDisplayController> _itemDisplayController;
		private inkWidgetLibraryReference _libraryPath;

		[Ordinal(2)] 
		[RED("itemNameText")] 
		public inkTextWidgetReference ItemNameText
		{
			get
			{
				if (_itemNameText == null)
				{
					_itemNameText = (inkTextWidgetReference) CR2WTypeManager.Create("inkTextWidgetReference", "itemNameText", cr2w, this);
				}
				return _itemNameText;
			}
			set
			{
				if (_itemNameText == value)
				{
					return;
				}
				_itemNameText = value;
				PropertySet(this);
			}
		}

		[Ordinal(3)] 
		[RED("buttonHintsRoot")] 
		public inkWidgetReference ButtonHintsRoot
		{
			get
			{
				if (_buttonHintsRoot == null)
				{
					_buttonHintsRoot = (inkWidgetReference) CR2WTypeManager.Create("inkWidgetReference", "buttonHintsRoot", cr2w, this);
				}
				return _buttonHintsRoot;
			}
			set
			{
				if (_buttonHintsRoot == value)
				{
					return;
				}
				_buttonHintsRoot = value;
				PropertySet(this);
			}
		}

		[Ordinal(4)] 
		[RED("itemDisplayRef")] 
		public inkWidgetReference ItemDisplayRef
		{
			get
			{
				if (_itemDisplayRef == null)
				{
					_itemDisplayRef = (inkWidgetReference) CR2WTypeManager.Create("inkWidgetReference", "itemDisplayRef", cr2w, this);
				}
				return _itemDisplayRef;
			}
			set
			{
				if (_itemDisplayRef == value)
				{
					return;
				}
				_itemDisplayRef = value;
				PropertySet(this);
			}
		}

		[Ordinal(5)] 
		[RED("rairtyBar")] 
		public inkWidgetReference RairtyBar
		{
			get
			{
				if (_rairtyBar == null)
				{
					_rairtyBar = (inkWidgetReference) CR2WTypeManager.Create("inkWidgetReference", "rairtyBar", cr2w, this);
				}
				return _rairtyBar;
			}
			set
			{
				if (_rairtyBar == value)
				{
					return;
				}
				_rairtyBar = value;
				PropertySet(this);
			}
		}

		[Ordinal(6)] 
		[RED("eqippedItemContainer")] 
		public inkWidgetReference EqippedItemContainer
		{
			get
			{
				if (_eqippedItemContainer == null)
				{
					_eqippedItemContainer = (inkWidgetReference) CR2WTypeManager.Create("inkWidgetReference", "eqippedItemContainer", cr2w, this);
				}
				return _eqippedItemContainer;
			}
			set
			{
				if (_eqippedItemContainer == value)
				{
					return;
				}
				_eqippedItemContainer = value;
				PropertySet(this);
			}
		}

		[Ordinal(7)] 
		[RED("itemPriceContainer")] 
		public inkWidgetReference ItemPriceContainer
		{
			get
			{
				if (_itemPriceContainer == null)
				{
					_itemPriceContainer = (inkWidgetReference) CR2WTypeManager.Create("inkWidgetReference", "itemPriceContainer", cr2w, this);
				}
				return _itemPriceContainer;
			}
			set
			{
				if (_itemPriceContainer == value)
				{
					return;
				}
				_itemPriceContainer = value;
				PropertySet(this);
			}
		}

		[Ordinal(8)] 
		[RED("itemPriceText")] 
		public inkTextWidgetReference ItemPriceText
		{
			get
			{
				if (_itemPriceText == null)
				{
					_itemPriceText = (inkTextWidgetReference) CR2WTypeManager.Create("inkTextWidgetReference", "itemPriceText", cr2w, this);
				}
				return _itemPriceText;
			}
			set
			{
				if (_itemPriceText == value)
				{
					return;
				}
				_itemPriceText = value;
				PropertySet(this);
			}
		}

		[Ordinal(9)] 
		[RED("root")] 
		public inkWidgetReference Root
		{
			get
			{
				if (_root == null)
				{
					_root = (inkWidgetReference) CR2WTypeManager.Create("inkWidgetReference", "root", cr2w, this);
				}
				return _root;
			}
			set
			{
				if (_root == value)
				{
					return;
				}
				_root = value;
				PropertySet(this);
			}
		}

		[Ordinal(10)] 
		[RED("background")] 
		public inkWidgetReference Background
		{
			get
			{
				if (_background == null)
				{
					_background = (inkWidgetReference) CR2WTypeManager.Create("inkWidgetReference", "background", cr2w, this);
				}
				return _background;
			}
			set
			{
				if (_background == value)
				{
					return;
				}
				_background = value;
				PropertySet(this);
			}
		}

		[Ordinal(11)] 
		[RED("closeData")] 
		public CHandle<VendorConfirmationPopupCloseData> CloseData
		{
			get
			{
				if (_closeData == null)
				{
					_closeData = (CHandle<VendorConfirmationPopupCloseData>) CR2WTypeManager.Create("handle:VendorConfirmationPopupCloseData", "closeData", cr2w, this);
				}
				return _closeData;
			}
			set
			{
				if (_closeData == value)
				{
					return;
				}
				_closeData = value;
				PropertySet(this);
			}
		}

		[Ordinal(12)] 
		[RED("buttonHintsController")] 
		public wCHandle<ButtonHints> ButtonHintsController
		{
			get
			{
				if (_buttonHintsController == null)
				{
					_buttonHintsController = (wCHandle<ButtonHints>) CR2WTypeManager.Create("whandle:ButtonHints", "buttonHintsController", cr2w, this);
				}
				return _buttonHintsController;
			}
			set
			{
				if (_buttonHintsController == value)
				{
					return;
				}
				_buttonHintsController = value;
				PropertySet(this);
			}
		}

		[Ordinal(13)] 
		[RED("gameData")] 
		public CHandle<gameItemData> GameData
		{
			get
			{
				if (_gameData == null)
				{
					_gameData = (CHandle<gameItemData>) CR2WTypeManager.Create("handle:gameItemData", "gameData", cr2w, this);
				}
				return _gameData;
			}
			set
			{
				if (_gameData == value)
				{
					return;
				}
				_gameData = value;
				PropertySet(this);
			}
		}

		[Ordinal(14)] 
		[RED("buttonOk")] 
		public inkWidgetReference ButtonOk
		{
			get
			{
				if (_buttonOk == null)
				{
					_buttonOk = (inkWidgetReference) CR2WTypeManager.Create("inkWidgetReference", "buttonOk", cr2w, this);
				}
				return _buttonOk;
			}
			set
			{
				if (_buttonOk == value)
				{
					return;
				}
				_buttonOk = value;
				PropertySet(this);
			}
		}

		[Ordinal(15)] 
		[RED("buttonCancel")] 
		public inkWidgetReference ButtonCancel
		{
			get
			{
				if (_buttonCancel == null)
				{
					_buttonCancel = (inkWidgetReference) CR2WTypeManager.Create("inkWidgetReference", "buttonCancel", cr2w, this);
				}
				return _buttonCancel;
			}
			set
			{
				if (_buttonCancel == value)
				{
					return;
				}
				_buttonCancel = value;
				PropertySet(this);
			}
		}

		[Ordinal(16)] 
		[RED("data")] 
		public CHandle<VendorConfirmationPopupData> Data
		{
			get
			{
				if (_data == null)
				{
					_data = (CHandle<VendorConfirmationPopupData>) CR2WTypeManager.Create("handle:VendorConfirmationPopupData", "data", cr2w, this);
				}
				return _data;
			}
			set
			{
				if (_data == value)
				{
					return;
				}
				_data = value;
				PropertySet(this);
			}
		}

		[Ordinal(17)] 
		[RED("itemDisplayController")] 
		public CHandle<InventoryItemDisplayController> ItemDisplayController
		{
			get
			{
				if (_itemDisplayController == null)
				{
					_itemDisplayController = (CHandle<InventoryItemDisplayController>) CR2WTypeManager.Create("handle:InventoryItemDisplayController", "itemDisplayController", cr2w, this);
				}
				return _itemDisplayController;
			}
			set
			{
				if (_itemDisplayController == value)
				{
					return;
				}
				_itemDisplayController = value;
				PropertySet(this);
			}
		}

		[Ordinal(18)] 
		[RED("libraryPath")] 
		public inkWidgetLibraryReference LibraryPath
		{
			get
			{
				if (_libraryPath == null)
				{
					_libraryPath = (inkWidgetLibraryReference) CR2WTypeManager.Create("inkWidgetLibraryReference", "libraryPath", cr2w, this);
				}
				return _libraryPath;
			}
			set
			{
				if (_libraryPath == value)
				{
					return;
				}
				_libraryPath = value;
				PropertySet(this);
			}
		}

		public VendorConfirmationPopup(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
