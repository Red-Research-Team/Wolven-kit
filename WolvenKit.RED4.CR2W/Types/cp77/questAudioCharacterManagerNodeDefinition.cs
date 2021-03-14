using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questAudioCharacterManagerNodeDefinition : questDisableableNodeDefinition
	{
		private CHandle<questIAudioCharacterManager_NodeType> _type;

		[Ordinal(2)] 
		[RED("type")] 
		public CHandle<questIAudioCharacterManager_NodeType> Type
		{
			get
			{
				if (_type == null)
				{
					_type = (CHandle<questIAudioCharacterManager_NodeType>) CR2WTypeManager.Create("handle:questIAudioCharacterManager_NodeType", "type", cr2w, this);
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

		public questAudioCharacterManagerNodeDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
