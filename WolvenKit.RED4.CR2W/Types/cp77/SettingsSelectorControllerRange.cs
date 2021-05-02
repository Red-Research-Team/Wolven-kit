using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class SettingsSelectorControllerRange : inkSettingsSelectorController
	{
		private inkTextWidgetReference _valueText;
		private inkWidgetReference _leftArrow;
		private inkWidgetReference _rightArrow;
		private inkWidgetReference _progressBar;

		[Ordinal(15)] 
		[RED("ValueText")] 
		public inkTextWidgetReference ValueText
		{
			get => GetProperty(ref _valueText);
			set => SetProperty(ref _valueText, value);
		}

		[Ordinal(16)] 
		[RED("LeftArrow")] 
		public inkWidgetReference LeftArrow
		{
			get => GetProperty(ref _leftArrow);
			set => SetProperty(ref _leftArrow, value);
		}

		[Ordinal(17)] 
		[RED("RightArrow")] 
		public inkWidgetReference RightArrow
		{
			get => GetProperty(ref _rightArrow);
			set => SetProperty(ref _rightArrow, value);
		}

		[Ordinal(18)] 
		[RED("ProgressBar")] 
		public inkWidgetReference ProgressBar
		{
			get => GetProperty(ref _progressBar);
			set => SetProperty(ref _progressBar, value);
		}

		public SettingsSelectorControllerRange(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
