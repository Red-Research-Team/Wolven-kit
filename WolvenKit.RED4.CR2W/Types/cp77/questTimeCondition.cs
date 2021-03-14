using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questTimeCondition : questTypedCondition
	{
		private CHandle<questITimeConditionType> _type;

		[Ordinal(0)] 
		[RED("type")] 
		public CHandle<questITimeConditionType> Type
		{
			get
			{
				if (_type == null)
				{
					_type = (CHandle<questITimeConditionType>) CR2WTypeManager.Create("handle:questITimeConditionType", "type", cr2w, this);
				}
				return _type;
			}
			set
			{
				if (_type == value)
				{
					return;
				}
				_type = value;
				PropertySet(this);
			}
		}

		public questTimeCondition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
