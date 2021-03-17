using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class scneventsPlayerLookAtEvent : scnSceneEvent
	{
		private scnPerformerId _performer;
		private NodeRef _nodeRef;
		private scneventsPlayerLookAtEventParams _lookAtParams;

		[Ordinal(6)] 
		[RED("performer")] 
		public scnPerformerId Performer
		{
			get => GetProperty(ref _performer);
			set => SetProperty(ref _performer, value);
		}

		[Ordinal(7)] 
		[RED("nodeRef")] 
		public NodeRef NodeRef
		{
			get => GetProperty(ref _nodeRef);
			set => SetProperty(ref _nodeRef, value);
		}

		[Ordinal(8)] 
		[RED("lookAtParams")] 
		public scneventsPlayerLookAtEventParams LookAtParams
		{
			get => GetProperty(ref _lookAtParams);
			set => SetProperty(ref _lookAtParams, value);
		}

		public scneventsPlayerLookAtEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
