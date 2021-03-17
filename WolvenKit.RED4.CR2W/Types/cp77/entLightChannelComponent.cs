using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class entLightChannelComponent : entIVisualComponent
	{
		private CBool _isEnabled;
		private CEnum<rendLightChannel> _channels;
		private CHandle<GeometryShape> _shape;

		[Ordinal(8)] 
		[RED("isEnabled")] 
		public CBool IsEnabled
		{
			get => GetProperty(ref _isEnabled);
			set => SetProperty(ref _isEnabled, value);
		}

		[Ordinal(9)] 
		[RED("channels")] 
		public CEnum<rendLightChannel> Channels
		{
			get => GetProperty(ref _channels);
			set => SetProperty(ref _channels, value);
		}

		[Ordinal(10)] 
		[RED("shape")] 
		public CHandle<GeometryShape> Shape
		{
			get => GetProperty(ref _shape);
			set => SetProperty(ref _shape, value);
		}

		public entLightChannelComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
