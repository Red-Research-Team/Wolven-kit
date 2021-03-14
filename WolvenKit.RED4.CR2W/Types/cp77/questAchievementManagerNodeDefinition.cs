using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questAchievementManagerNodeDefinition : questDisableableNodeDefinition
	{
		private CHandle<questIAchievementManagerNodeType> _type;

		[Ordinal(2)] 
		[RED("type")] 
		public CHandle<questIAchievementManagerNodeType> Type
		{
			get
			{
				if (_type == null)
				{
					_type = (CHandle<questIAchievementManagerNodeType>) CR2WTypeManager.Create("handle:questIAchievementManagerNodeType", "type", cr2w, this);
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

		public questAchievementManagerNodeDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
