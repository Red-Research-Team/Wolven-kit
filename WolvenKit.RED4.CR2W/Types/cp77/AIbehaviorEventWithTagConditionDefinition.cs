using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class AIbehaviorEventWithTagConditionDefinition : AIbehaviorConditionDefinition
	{
		private CName _tag;
		private CBool _consumeEvent;

		[Ordinal(1)] 
		[RED("tag")] 
		public CName Tag
		{
			get => GetProperty(ref _tag);
			set => SetProperty(ref _tag, value);
		}

		[Ordinal(2)] 
		[RED("consumeEvent")] 
		public CBool ConsumeEvent
		{
			get => GetProperty(ref _consumeEvent);
			set => SetProperty(ref _consumeEvent, value);
		}

		public AIbehaviorEventWithTagConditionDefinition(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
