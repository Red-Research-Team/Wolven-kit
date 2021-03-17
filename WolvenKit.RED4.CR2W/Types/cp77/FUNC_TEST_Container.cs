using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class FUNC_TEST_Container : CVariable
	{
		private inkBasePanelWidgetReference _basePanel;
		private inkCompoundWidgetReference _compound;
		private inkLeafWidgetReference _leaf;
		private inkWidgetReference _widget;

		[Ordinal(0)] 
		[RED("BasePanel")] 
		public inkBasePanelWidgetReference BasePanel
		{
			get => GetProperty(ref _basePanel);
			set => SetProperty(ref _basePanel, value);
		}

		[Ordinal(1)] 
		[RED("Compound")] 
		public inkCompoundWidgetReference Compound
		{
			get => GetProperty(ref _compound);
			set => SetProperty(ref _compound, value);
		}

		[Ordinal(2)] 
		[RED("Leaf")] 
		public inkLeafWidgetReference Leaf
		{
			get => GetProperty(ref _leaf);
			set => SetProperty(ref _leaf, value);
		}

		[Ordinal(3)] 
		[RED("Widget")] 
		public inkWidgetReference Widget
		{
			get => GetProperty(ref _widget);
			set => SetProperty(ref _widget, value);
		}

		public FUNC_TEST_Container(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
