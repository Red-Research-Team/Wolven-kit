using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class ImageSwappingController : inkWidgetLogicController
	{
		private CString _imageWidgetPath;
		private CArray<CName> _buttonsPaths;
		private CArray<CString> _buttonsNames;
		private CArray<CString> _buttonsValues;
		private CArray<wCHandle<inkCanvasWidget>> _buttons;

		[Ordinal(1)] 
		[RED("ImageWidgetPath")] 
		public CString ImageWidgetPath
		{
			get => GetProperty(ref _imageWidgetPath);
			set => SetProperty(ref _imageWidgetPath, value);
		}

		[Ordinal(2)] 
		[RED("ButtonsPaths")] 
		public CArray<CName> ButtonsPaths
		{
			get => GetProperty(ref _buttonsPaths);
			set => SetProperty(ref _buttonsPaths, value);
		}

		[Ordinal(3)] 
		[RED("ButtonsNames")] 
		public CArray<CString> ButtonsNames
		{
			get => GetProperty(ref _buttonsNames);
			set => SetProperty(ref _buttonsNames, value);
		}

		[Ordinal(4)] 
		[RED("ButtonsValues")] 
		public CArray<CString> ButtonsValues
		{
			get => GetProperty(ref _buttonsValues);
			set => SetProperty(ref _buttonsValues, value);
		}

		[Ordinal(5)] 
		[RED("Buttons")] 
		public CArray<wCHandle<inkCanvasWidget>> Buttons
		{
			get => GetProperty(ref _buttons);
			set => SetProperty(ref _buttons, value);
		}

		public ImageSwappingController(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
