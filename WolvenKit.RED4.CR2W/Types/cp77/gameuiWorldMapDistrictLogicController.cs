using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameuiWorldMapDistrictLogicController : inkWidgetLogicController
	{
		private wCHandle<gamedataDistrict_Record> _record;
		private CEnum<gamedataDistrict> _type;
		private CBool _selected;
		private inkLinePatternWidgetReference _outlineWidget;
		private inkImageWidgetReference _iconWidget;
		private CHandle<inkanimProxy> _selectAnim;

		[Ordinal(1)] 
		[RED("record")] 
		public wCHandle<gamedataDistrict_Record> Record
		{
			get => GetProperty(ref _record);
			set => SetProperty(ref _record, value);
		}

		[Ordinal(2)] 
		[RED("type")] 
		public CEnum<gamedataDistrict> Type
		{
			get => GetProperty(ref _type);
			set => SetProperty(ref _type, value);
		}

		[Ordinal(3)] 
		[RED("selected")] 
		public CBool Selected
		{
			get => GetProperty(ref _selected);
			set => SetProperty(ref _selected, value);
		}

		[Ordinal(4)] 
		[RED("outlineWidget")] 
		public inkLinePatternWidgetReference OutlineWidget
		{
			get => GetProperty(ref _outlineWidget);
			set => SetProperty(ref _outlineWidget, value);
		}

		[Ordinal(5)] 
		[RED("iconWidget")] 
		public inkImageWidgetReference IconWidget
		{
			get => GetProperty(ref _iconWidget);
			set => SetProperty(ref _iconWidget, value);
		}

		[Ordinal(6)] 
		[RED("selectAnim")] 
		public CHandle<inkanimProxy> SelectAnim
		{
			get => GetProperty(ref _selectAnim);
			set => SetProperty(ref _selectAnim, value);
		}

		public gameuiWorldMapDistrictLogicController(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
