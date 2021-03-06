using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class entdismembermentPhysicsInfo : CVariable
	{
		private CFloat _densityScale;

		[Ordinal(0)] 
		[RED("DensityScale")] 
		public CFloat DensityScale
		{
			get => GetProperty(ref _densityScale);
			set => SetProperty(ref _densityScale, value);
		}

		public entdismembermentPhysicsInfo(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
