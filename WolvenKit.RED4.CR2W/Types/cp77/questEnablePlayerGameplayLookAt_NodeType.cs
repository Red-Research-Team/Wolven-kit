using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questEnablePlayerGameplayLookAt_NodeType : questISceneManagerNodeType
	{
		private CBool _enable;

		[Ordinal(0)] 
		[RED("enable")] 
		public CBool Enable
		{
			get => GetProperty(ref _enable);
			set => SetProperty(ref _enable, value);
		}

		public questEnablePlayerGameplayLookAt_NodeType(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
