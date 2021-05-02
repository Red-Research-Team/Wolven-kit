using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimNode_TriggerBranch : animAnimNode_Base
	{
		private animPoseLink _base;
		private animPoseLink _overlay;
		private CFloat _blendIn;
		private CFloat _blendOut;
		private CName _startEvent;
		private CName _endEvent;
		private CFloat _cooldown;

		[Ordinal(11)] 
		[RED("base")] 
		public animPoseLink Base
		{
			get => GetProperty(ref _base);
			set => SetProperty(ref _base, value);
		}

		[Ordinal(12)] 
		[RED("overlay")] 
		public animPoseLink Overlay
		{
			get => GetProperty(ref _overlay);
			set => SetProperty(ref _overlay, value);
		}

		[Ordinal(13)] 
		[RED("blendIn")] 
		public CFloat BlendIn
		{
			get => GetProperty(ref _blendIn);
			set => SetProperty(ref _blendIn, value);
		}

		[Ordinal(14)] 
		[RED("blendOut")] 
		public CFloat BlendOut
		{
			get => GetProperty(ref _blendOut);
			set => SetProperty(ref _blendOut, value);
		}

		[Ordinal(15)] 
		[RED("startEvent")] 
		public CName StartEvent
		{
			get => GetProperty(ref _startEvent);
			set => SetProperty(ref _startEvent, value);
		}

		[Ordinal(16)] 
		[RED("endEvent")] 
		public CName EndEvent
		{
			get => GetProperty(ref _endEvent);
			set => SetProperty(ref _endEvent, value);
		}

		[Ordinal(17)] 
		[RED("cooldown")] 
		public CFloat Cooldown
		{
			get => GetProperty(ref _cooldown);
			set => SetProperty(ref _cooldown, value);
		}

		public animAnimNode_TriggerBranch(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
