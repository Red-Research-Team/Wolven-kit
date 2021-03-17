using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class interopTerrainEditToolCreationSlotInfo : CVariable
	{
		private Vector2 _scale;
		private CBool _heightMappingOverrideEnable;
		private CFloat _heightMappingMin;
		private CFloat _heightMappingMax;

		[Ordinal(0)] 
		[RED("scale")] 
		public Vector2 Scale
		{
			get => GetProperty(ref _scale);
			set => SetProperty(ref _scale, value);
		}

		[Ordinal(1)] 
		[RED("heightMappingOverrideEnable")] 
		public CBool HeightMappingOverrideEnable
		{
			get => GetProperty(ref _heightMappingOverrideEnable);
			set => SetProperty(ref _heightMappingOverrideEnable, value);
		}

		[Ordinal(2)] 
		[RED("heightMappingMin")] 
		public CFloat HeightMappingMin
		{
			get => GetProperty(ref _heightMappingMin);
			set => SetProperty(ref _heightMappingMin, value);
		}

		[Ordinal(3)] 
		[RED("heightMappingMax")] 
		public CFloat HeightMappingMax
		{
			get => GetProperty(ref _heightMappingMax);
			set => SetProperty(ref _heightMappingMax, value);
		}

		public interopTerrainEditToolCreationSlotInfo(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
