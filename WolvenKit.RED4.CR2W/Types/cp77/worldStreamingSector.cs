using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class worldStreamingSector : CResource
	{
		private CArray<rRef<CResource>> _localInplaceResource;
		private raRef<worldStreamingSectorInplaceContent> _externInplaceResource;
		private CUInt8 _level;
		private CInt8 _category;

		[Ordinal(1)] 
		[RED("localInplaceResource")] 
		public CArray<rRef<CResource>> LocalInplaceResource
		{
			get => GetProperty(ref _localInplaceResource);
			set => SetProperty(ref _localInplaceResource, value);
		}

		[Ordinal(2)] 
		[RED("externInplaceResource")] 
		public raRef<worldStreamingSectorInplaceContent> ExternInplaceResource
		{
			get => GetProperty(ref _externInplaceResource);
			set => SetProperty(ref _externInplaceResource, value);
		}

		[Ordinal(3)] 
		[RED("level")] 
		public CUInt8 Level
		{
			get => GetProperty(ref _level);
			set => SetProperty(ref _level, value);
		}

		[Ordinal(4)] 
		[RED("category")] 
		public CInt8 Category
		{
			get => GetProperty(ref _category);
			set => SetProperty(ref _category, value);
		}

		public worldStreamingSector(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
