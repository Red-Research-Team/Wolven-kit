using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questComparisonParam : ISerializable
	{
		private CBool _entireCommunity;
		private CUInt32 _count;
		private CEnum<EComparisonType> _comparisonType;

		[Ordinal(0)] 
		[RED("entireCommunity")] 
		public CBool EntireCommunity
		{
			get => GetProperty(ref _entireCommunity);
			set => SetProperty(ref _entireCommunity, value);
		}

		[Ordinal(1)] 
		[RED("count")] 
		public CUInt32 Count
		{
			get => GetProperty(ref _count);
			set => SetProperty(ref _count, value);
		}

		[Ordinal(2)] 
		[RED("comparisonType")] 
		public CEnum<EComparisonType> ComparisonType
		{
			get => GetProperty(ref _comparisonType);
			set => SetProperty(ref _comparisonType, value);
		}

		public questComparisonParam(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
