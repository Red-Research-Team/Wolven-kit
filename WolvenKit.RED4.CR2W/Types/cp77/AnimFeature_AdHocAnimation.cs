using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class AnimFeature_AdHocAnimation : animAnimFeature
	{
		private CBool _isActive;
		private CBool _useBothHands;
		private CInt32 _animationIndex;

		[Ordinal(0)] 
		[RED("isActive")] 
		public CBool IsActive
		{
			get => GetProperty(ref _isActive);
			set => SetProperty(ref _isActive, value);
		}

		[Ordinal(1)] 
		[RED("useBothHands")] 
		public CBool UseBothHands
		{
			get => GetProperty(ref _useBothHands);
			set => SetProperty(ref _useBothHands, value);
		}

		[Ordinal(2)] 
		[RED("animationIndex")] 
		public CInt32 AnimationIndex
		{
			get => GetProperty(ref _animationIndex);
			set => SetProperty(ref _animationIndex, value);
		}

		public AnimFeature_AdHocAnimation(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
