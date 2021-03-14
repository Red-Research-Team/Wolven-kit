using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimNode_SetRequiredDistanceCategory : animAnimNode_OnePoseInput
	{
		private CUInt32 _requiredQualityDistanceCategory;

		[Ordinal(12)] 
		[RED("requiredQualityDistanceCategory")] 
		public CUInt32 RequiredQualityDistanceCategory
		{
			get
			{
				if (_requiredQualityDistanceCategory == null)
				{
					_requiredQualityDistanceCategory = (CUInt32) CR2WTypeManager.Create("Uint32", "requiredQualityDistanceCategory", cr2w, this);
				}
				return _requiredQualityDistanceCategory;
			}
			set
			{
				if (_requiredQualityDistanceCategory == value)
				{
					return;
				}
				_requiredQualityDistanceCategory = value;
				PropertySet(this);
			}
		}

		public animAnimNode_SetRequiredDistanceCategory(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
