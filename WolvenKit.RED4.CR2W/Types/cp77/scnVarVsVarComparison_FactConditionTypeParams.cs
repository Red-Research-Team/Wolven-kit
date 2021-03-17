using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class scnVarVsVarComparison_FactConditionTypeParams : CVariable
	{
		private CName _factName1;
		private CName _factName2;
		private CEnum<EComparisonType> _comparisonType;

		[Ordinal(0)] 
		[RED("factName1")] 
		public CName FactName1
		{
			get => GetProperty(ref _factName1);
			set => SetProperty(ref _factName1, value);
		}

		[Ordinal(1)] 
		[RED("factName2")] 
		public CName FactName2
		{
			get => GetProperty(ref _factName2);
			set => SetProperty(ref _factName2, value);
		}

		[Ordinal(2)] 
		[RED("comparisonType")] 
		public CEnum<EComparisonType> ComparisonType
		{
			get => GetProperty(ref _comparisonType);
			set => SetProperty(ref _comparisonType, value);
		}

		public scnVarVsVarComparison_FactConditionTypeParams(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
