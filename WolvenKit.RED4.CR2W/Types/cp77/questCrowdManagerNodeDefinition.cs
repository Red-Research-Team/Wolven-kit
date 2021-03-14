using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questCrowdManagerNodeDefinition : questDisableableNodeDefinition
	{
		private CHandle<questICrowdManager_NodeType> _type;

		[Ordinal(2)] 
		[RED("type")] 
		public CHandle<questICrowdManager_NodeType> Type
		{
			get
			{
				if (_type == null)
				{
					_type = (CHandle<questICrowdManager_NodeType>) CR2WTypeManager.Create("handle:questICrowdManager_NodeType", "type", cr2w, this);
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

		public questCrowdManagerNodeDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
