using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questCameraClippingPlane_NodeType : questISceneManagerNodeType
	{
		private CEnum<questCameraPlanesPreset> _preset;

		[Ordinal(0)] 
		[RED("preset")] 
		public CEnum<questCameraPlanesPreset> Preset
		{
			get => GetProperty(ref _preset);
			set => SetProperty(ref _preset, value);
		}

		public questCameraClippingPlane_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
