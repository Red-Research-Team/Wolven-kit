using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class BuildBluelinePart : gameinteractionsvisBluelinePart
	{
		private CHandle<gamedataPlayerBuild_Record> _record;
		private CInt32 _lhsValue;
		private CInt32 _rhsValue;
		private CEnum<ECompareOp> _comparisonOperator;

		[Ordinal(2)] 
		[RED("record")] 
		public CHandle<gamedataPlayerBuild_Record> Record
		{
			get => GetProperty(ref _record);
			set => SetProperty(ref _record, value);
		}

		[Ordinal(3)] 
		[RED("lhsValue")] 
		public CInt32 LhsValue
		{
			get => GetProperty(ref _lhsValue);
			set => SetProperty(ref _lhsValue, value);
		}

		[Ordinal(4)] 
		[RED("rhsValue")] 
		public CInt32 RhsValue
		{
			get => GetProperty(ref _rhsValue);
			set => SetProperty(ref _rhsValue, value);
		}

		[Ordinal(5)] 
		[RED("comparisonOperator")] 
		public CEnum<ECompareOp> ComparisonOperator
		{
			get => GetProperty(ref _comparisonOperator);
			set => SetProperty(ref _comparisonOperator, value);
		}

		public BuildBluelinePart(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
