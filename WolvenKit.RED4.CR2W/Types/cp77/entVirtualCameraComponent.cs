using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class entVirtualCameraComponent : entBaseCameraComponent
	{
		private CName _virtualCameraName;
		private CUInt32 _resolutionWidth;
		private CUInt32 _resolutionHeight;
		private CBool _drawBackground;
		private CBool _isEnabled;

		[Ordinal(10)] 
		[RED("virtualCameraName")] 
		public CName VirtualCameraName
		{
			get => GetProperty(ref _virtualCameraName);
			set => SetProperty(ref _virtualCameraName, value);
		}

		[Ordinal(11)] 
		[RED("resolutionWidth")] 
		public CUInt32 ResolutionWidth
		{
			get => GetProperty(ref _resolutionWidth);
			set => SetProperty(ref _resolutionWidth, value);
		}

		[Ordinal(12)] 
		[RED("resolutionHeight")] 
		public CUInt32 ResolutionHeight
		{
			get => GetProperty(ref _resolutionHeight);
			set => SetProperty(ref _resolutionHeight, value);
		}

		[Ordinal(13)] 
		[RED("drawBackground")] 
		public CBool DrawBackground
		{
			get => GetProperty(ref _drawBackground);
			set => SetProperty(ref _drawBackground, value);
		}

		[Ordinal(14)] 
		[RED("isEnabled")] 
		public CBool IsEnabled
		{
			get => GetProperty(ref _isEnabled);
			set => SetProperty(ref _isEnabled, value);
		}

		public entVirtualCameraComponent(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
