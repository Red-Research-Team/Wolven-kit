using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameuiInputHintGroupData : CVariable
	{
		private TweakDBID _iconReference;
		private CString _localizedTitle;
		private CString _localizedDescription;
		private CInt32 _sortingPriority;

		[Ordinal(0)] 
		[RED("iconReference")] 
		public TweakDBID IconReference
		{
			get => GetProperty(ref _iconReference);
			set => SetProperty(ref _iconReference, value);
		}

		[Ordinal(1)] 
		[RED("localizedTitle")] 
		public CString LocalizedTitle
		{
			get => GetProperty(ref _localizedTitle);
			set => SetProperty(ref _localizedTitle, value);
		}

		[Ordinal(2)] 
		[RED("localizedDescription")] 
		public CString LocalizedDescription
		{
			get => GetProperty(ref _localizedDescription);
			set => SetProperty(ref _localizedDescription, value);
		}

		[Ordinal(3)] 
		[RED("sortingPriority")] 
		public CInt32 SortingPriority
		{
			get => GetProperty(ref _sortingPriority);
			set => SetProperty(ref _sortingPriority, value);
		}

		public gameuiInputHintGroupData(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
