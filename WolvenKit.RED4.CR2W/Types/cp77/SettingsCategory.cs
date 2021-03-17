using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class SettingsCategory : CVariable
	{
		private CName _label;
		private CArray<SettingsCategory> _subcategories;
		private CArray<CHandle<userSettingsVar>> _options;
		private CBool _isEmpty;
		private CName _groupPath;

		[Ordinal(0)] 
		[RED("label")] 
		public CName Label
		{
			get => GetProperty(ref _label);
			set => SetProperty(ref _label, value);
		}

		[Ordinal(1)] 
		[RED("subcategories")] 
		public CArray<SettingsCategory> Subcategories
		{
			get => GetProperty(ref _subcategories);
			set => SetProperty(ref _subcategories, value);
		}

		[Ordinal(2)] 
		[RED("options")] 
		public CArray<CHandle<userSettingsVar>> Options
		{
			get => GetProperty(ref _options);
			set => SetProperty(ref _options, value);
		}

		[Ordinal(3)] 
		[RED("isEmpty")] 
		public CBool IsEmpty
		{
			get => GetProperty(ref _isEmpty);
			set => SetProperty(ref _isEmpty, value);
		}

		[Ordinal(4)] 
		[RED("groupPath")] 
		public CName GroupPath
		{
			get => GetProperty(ref _groupPath);
			set => SetProperty(ref _groupPath, value);
		}

		public SettingsCategory(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
