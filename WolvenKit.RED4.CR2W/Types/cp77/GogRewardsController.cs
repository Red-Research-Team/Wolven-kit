using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class GogRewardsController : inkWidgetLogicController
	{
		private inkWidgetReference _containerWidget;

		[Ordinal(1)] 
		[RED("containerWidget")] 
		public inkWidgetReference ContainerWidget
		{
			get => GetProperty(ref _containerWidget);
			set => SetProperty(ref _containerWidget, value);
		}

		public GogRewardsController(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
