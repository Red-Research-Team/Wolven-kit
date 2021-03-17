using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class AIJoinTargetsSquad : AICommand
	{
		private gameEntityReference _targetPuppetRef;

		[Ordinal(4)] 
		[RED("targetPuppetRef")] 
		public gameEntityReference TargetPuppetRef
		{
			get => GetProperty(ref _targetPuppetRef);
			set => SetProperty(ref _targetPuppetRef, value);
		}

		public AIJoinTargetsSquad(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
