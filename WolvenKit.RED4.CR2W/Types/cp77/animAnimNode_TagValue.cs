using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimNode_TagValue : animAnimNode_FloatValue
	{
		private CName _tag;
		private CFloat _defaultValue;
		private CBool _oneMinus;

		[Ordinal(11)] 
		[RED("tag")] 
		public CName Tag
		{
			get => GetProperty(ref _tag);
			set => SetProperty(ref _tag, value);
		}

		[Ordinal(12)] 
		[RED("defaultValue")] 
		public CFloat DefaultValue
		{
			get => GetProperty(ref _defaultValue);
			set => SetProperty(ref _defaultValue, value);
		}

		[Ordinal(13)] 
		[RED("oneMinus")] 
		public CBool OneMinus
		{
			get => GetProperty(ref _oneMinus);
			set => SetProperty(ref _oneMinus, value);
		}

		public animAnimNode_TagValue(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
