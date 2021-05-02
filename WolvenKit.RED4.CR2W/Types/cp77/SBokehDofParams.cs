using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class SBokehDofParams : CVariable
	{
		private CBool _enabled;
		private CFloat _hexToCircleScale;
		private CBool _usePhysicalSetup;
		private CFloat _planeInFocus;
		private CEnum<EApertureValue> _fStops;
		private CFloat _bokehSizeMuliplier;

		[Ordinal(0)] 
		[RED("enabled")] 
		public CBool Enabled
		{
			get => GetProperty(ref _enabled);
			set => SetProperty(ref _enabled, value);
		}

		[Ordinal(1)] 
		[RED("hexToCircleScale")] 
		public CFloat HexToCircleScale
		{
			get => GetProperty(ref _hexToCircleScale);
			set => SetProperty(ref _hexToCircleScale, value);
		}

		[Ordinal(2)] 
		[RED("usePhysicalSetup")] 
		public CBool UsePhysicalSetup
		{
			get => GetProperty(ref _usePhysicalSetup);
			set => SetProperty(ref _usePhysicalSetup, value);
		}

		[Ordinal(3)] 
		[RED("planeInFocus")] 
		public CFloat PlaneInFocus
		{
			get => GetProperty(ref _planeInFocus);
			set => SetProperty(ref _planeInFocus, value);
		}

		[Ordinal(4)] 
		[RED("fStops")] 
		public CEnum<EApertureValue> FStops
		{
			get => GetProperty(ref _fStops);
			set => SetProperty(ref _fStops, value);
		}

		[Ordinal(5)] 
		[RED("bokehSizeMuliplier")] 
		public CFloat BokehSizeMuliplier
		{
			get => GetProperty(ref _bokehSizeMuliplier);
			set => SetProperty(ref _bokehSizeMuliplier, value);
		}

		public SBokehDofParams(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
