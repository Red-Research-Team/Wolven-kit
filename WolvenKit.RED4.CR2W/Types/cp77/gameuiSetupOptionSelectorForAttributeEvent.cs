using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameuiSetupOptionSelectorForAttributeEvent : redEvent
	{
		private CUInt32 _attribute;
		private CArray<gameuiPhotoModeOptionSelectorData> _values;
		private CInt32 _startDataValue;

		[Ordinal(0)] 
		[RED("attribute")] 
		public CUInt32 Attribute
		{
			get => GetProperty(ref _attribute);
			set => SetProperty(ref _attribute, value);
		}

		[Ordinal(1)] 
		[RED("values")] 
		public CArray<gameuiPhotoModeOptionSelectorData> Values
		{
			get => GetProperty(ref _values);
			set => SetProperty(ref _values, value);
		}

		[Ordinal(2)] 
		[RED("startDataValue")] 
		public CInt32 StartDataValue
		{
			get => GetProperty(ref _startDataValue);
			set => SetProperty(ref _startDataValue, value);
		}

		public gameuiSetupOptionSelectorForAttributeEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
