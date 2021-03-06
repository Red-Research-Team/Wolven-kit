using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class HitDistanceCoveredPrereq : GenericHitPrereq
	{
		private CFloat _distanceRequired;
		private CEnum<EComparisonType> _comparisonType;

		[Ordinal(5)] 
		[RED("distanceRequired")] 
		public CFloat DistanceRequired
		{
			get => GetProperty(ref _distanceRequired);
			set => SetProperty(ref _distanceRequired, value);
		}

		[Ordinal(6)] 
		[RED("comparisonType")] 
		public CEnum<EComparisonType> ComparisonType
		{
			get => GetProperty(ref _comparisonType);
			set => SetProperty(ref _comparisonType, value);
		}

		public HitDistanceCoveredPrereq(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
