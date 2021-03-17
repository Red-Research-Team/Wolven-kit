using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class MessengerContactsVirtualNestedListController : VirtualNestedListController
	{
		private wCHandle<MessengerContactDataView> _currentDataView;

		[Ordinal(13)] 
		[RED("currentDataView")] 
		public wCHandle<MessengerContactDataView> CurrentDataView
		{
			get => GetProperty(ref _currentDataView);
			set => SetProperty(ref _currentDataView, value);
		}

		public MessengerContactsVirtualNestedListController(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
