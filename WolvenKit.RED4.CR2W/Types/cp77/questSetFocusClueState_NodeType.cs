using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questSetFocusClueState_NodeType : questIVisionModeNodeType
	{
		private gameEntityReference _objectRef;
		private CInt32 _clueId;
		private CBool _clueState;

		[Ordinal(0)] 
		[RED("objectRef")] 
		public gameEntityReference ObjectRef
		{
			get => GetProperty(ref _objectRef);
			set => SetProperty(ref _objectRef, value);
		}

		[Ordinal(1)] 
		[RED("clueId")] 
		public CInt32 ClueId
		{
			get => GetProperty(ref _clueId);
			set => SetProperty(ref _clueId, value);
		}

		[Ordinal(2)] 
		[RED("clueState")] 
		public CBool ClueState
		{
			get => GetProperty(ref _clueState);
			set => SetProperty(ref _clueState, value);
		}

		public questSetFocusClueState_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
