using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimNode_FrozenFrame : animAnimNode_OnePoseInput
	{
		private CInt32 _maxFramesFrozen;
		private CName _triggerEventName;
		private CName _clearEventName;

		[Ordinal(12)] 
		[RED("maxFramesFrozen")] 
		public CInt32 MaxFramesFrozen
		{
			get => GetProperty(ref _maxFramesFrozen);
			set => SetProperty(ref _maxFramesFrozen, value);
		}

		[Ordinal(13)] 
		[RED("triggerEventName")] 
		public CName TriggerEventName
		{
			get => GetProperty(ref _triggerEventName);
			set => SetProperty(ref _triggerEventName, value);
		}

		[Ordinal(14)] 
		[RED("clearEventName")] 
		public CName ClearEventName
		{
			get => GetProperty(ref _clearEventName);
			set => SetProperty(ref _clearEventName, value);
		}

		public animAnimNode_FrozenFrame(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
