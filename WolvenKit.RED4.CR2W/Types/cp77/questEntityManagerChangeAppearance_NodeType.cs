using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questEntityManagerChangeAppearance_NodeType : questIEntityManager_NodeType
	{
		private gameEntityReference _entityRef;
		private CBool _prefetchOnly;
		private CName _appearanceName;

		[Ordinal(0)] 
		[RED("entityRef")] 
		public gameEntityReference EntityRef
		{
			get => GetProperty(ref _entityRef);
			set => SetProperty(ref _entityRef, value);
		}

		[Ordinal(1)] 
		[RED("prefetchOnly")] 
		public CBool PrefetchOnly
		{
			get => GetProperty(ref _prefetchOnly);
			set => SetProperty(ref _prefetchOnly, value);
		}

		[Ordinal(2)] 
		[RED("appearanceName")] 
		public CName AppearanceName
		{
			get => GetProperty(ref _appearanceName);
			set => SetProperty(ref _appearanceName, value);
		}

		public questEntityManagerChangeAppearance_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
