using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class inkStateTransitionAnimationController : inkWidgetLogicController
	{
		private CArray<inkWidgetStateAnimatedTransition> _transition;
		private CBool _stopActiveAnimation;

		[Ordinal(1)] 
		[RED("transition")] 
		public CArray<inkWidgetStateAnimatedTransition> Transition
		{
			get => GetProperty(ref _transition);
			set => SetProperty(ref _transition, value);
		}

		[Ordinal(2)] 
		[RED("stopActiveAnimation")] 
		public CBool StopActiveAnimation
		{
			get => GetProperty(ref _stopActiveAnimation);
			set => SetProperty(ref _stopActiveAnimation, value);
		}

		public inkStateTransitionAnimationController(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
