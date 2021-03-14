using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questMultiplayerAIDirectorNodeDefinition : questSignalStoppingNodeDefinition
	{
		private CHandle<questMultiplayerAIDirectorParams> _params;

		[Ordinal(2)] 
		[RED("params")] 
		public CHandle<questMultiplayerAIDirectorParams> Params
		{
			get
			{
				if (_params == null)
				{
					_params = (CHandle<questMultiplayerAIDirectorParams>) CR2WTypeManager.Create("handle:questMultiplayerAIDirectorParams", "params", cr2w, this);
				}
				return _params;
			}
			set
			{
				if (_params == value)
				{
					return;
				}
				_params = value;
				PropertySet(this);
			}
		}

		public questMultiplayerAIDirectorNodeDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
