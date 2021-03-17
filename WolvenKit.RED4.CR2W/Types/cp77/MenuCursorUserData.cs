using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class MenuCursorUserData : inkUserData
	{
		private CName _animationOverride;
		private CArray<CName> _actions;

		[Ordinal(0)] 
		[RED("animationOverride")] 
		public CName AnimationOverride
		{
			get => GetProperty(ref _animationOverride);
			set => SetProperty(ref _animationOverride, value);
		}

		[Ordinal(1)] 
		[RED("actions")] 
		public CArray<CName> Actions
		{
			get => GetProperty(ref _actions);
			set => SetProperty(ref _actions, value);
		}

		public MenuCursorUserData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
