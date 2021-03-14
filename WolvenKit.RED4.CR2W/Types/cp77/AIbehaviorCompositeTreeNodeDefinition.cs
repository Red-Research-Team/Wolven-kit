using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class AIbehaviorCompositeTreeNodeDefinition : AIbehaviorTreeNodeDefinition
	{
		private CArray<CHandle<AIbehaviorTreeNodeDefinition>> _children;

		[Ordinal(0)] 
		[RED("children")] 
		public CArray<CHandle<AIbehaviorTreeNodeDefinition>> Children
		{
			get
			{
				if (_children == null)
				{
					_children = (CArray<CHandle<AIbehaviorTreeNodeDefinition>>) CR2WTypeManager.Create("array:handle:AIbehaviorTreeNodeDefinition", "children", cr2w, this);
				}
				return _children;
			}
			set
			{
				if (_children == value)
				{
					return;
				}
				_children = value;
				PropertySet(this);
			}
		}

		public AIbehaviorCompositeTreeNodeDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
