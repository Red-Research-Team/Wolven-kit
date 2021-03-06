using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameuiMainMenuGameController : gameuiMenuItemListGameController
	{
		private inkCompoundWidgetReference _backgroundContainer;

		[Ordinal(6)] 
		[RED("backgroundContainer")] 
		public inkCompoundWidgetReference BackgroundContainer
		{
			get => GetProperty(ref _backgroundContainer);
			set => SetProperty(ref _backgroundContainer, value);
		}

		public gameuiMainMenuGameController(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
