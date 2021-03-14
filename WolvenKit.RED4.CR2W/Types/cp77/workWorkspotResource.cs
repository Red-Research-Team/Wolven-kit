using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class workWorkspotResource : animAnimGraph
	{
		private CHandle<workWorkspotTree> _workspotTree;

		[Ordinal(16)] 
		[RED("workspotTree")] 
		public CHandle<workWorkspotTree> WorkspotTree
		{
			get
			{
				if (_workspotTree == null)
				{
					_workspotTree = (CHandle<workWorkspotTree>) CR2WTypeManager.Create("handle:workWorkspotTree", "workspotTree", cr2w, this);
				}
				return _workspotTree;
			}
			set
			{
				if (_workspotTree == value)
				{
					return;
				}
				_workspotTree = value;
				PropertySet(this);
			}
		}

		public workWorkspotResource(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
