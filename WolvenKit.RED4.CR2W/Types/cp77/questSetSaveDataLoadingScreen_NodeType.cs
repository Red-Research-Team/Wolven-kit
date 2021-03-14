using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questSetSaveDataLoadingScreen_NodeType : questIUIManagerNodeType
	{
		private TweakDBID _selectedLoading;

		[Ordinal(0)] 
		[RED("selectedLoading")] 
		public TweakDBID SelectedLoading
		{
			get
			{
				if (_selectedLoading == null)
				{
					_selectedLoading = (TweakDBID) CR2WTypeManager.Create("TweakDBID", "selectedLoading", cr2w, this);
				}
				return _selectedLoading;
			}
			set
			{
				if (_selectedLoading == value)
				{
					return;
				}
				_selectedLoading = value;
				PropertySet(this);
			}
		}

		public questSetSaveDataLoadingScreen_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
