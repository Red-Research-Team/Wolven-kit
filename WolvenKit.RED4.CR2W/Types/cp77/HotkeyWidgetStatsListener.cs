using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class HotkeyWidgetStatsListener : gameScriptStatusEffectListener
	{
		private wCHandle<GenericHotkeyController> _controller;

		[Ordinal(0)] 
		[RED("controller")] 
		public wCHandle<GenericHotkeyController> Controller
		{
			get => GetProperty(ref _controller);
			set => SetProperty(ref _controller, value);
		}

		public HotkeyWidgetStatsListener(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
