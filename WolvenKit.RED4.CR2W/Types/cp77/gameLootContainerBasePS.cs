using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameLootContainerBasePS : gameObjectPS
	{
		private CBool _markAsQuest;
		private CBool _isDisabled;
		private CBool _isLocked;

		[Ordinal(0)] 
		[RED("markAsQuest")] 
		public CBool MarkAsQuest
		{
			get => GetProperty(ref _markAsQuest);
			set => SetProperty(ref _markAsQuest, value);
		}

		[Ordinal(1)] 
		[RED("isDisabled")] 
		public CBool IsDisabled
		{
			get => GetProperty(ref _isDisabled);
			set => SetProperty(ref _isDisabled, value);
		}

		[Ordinal(2)] 
		[RED("isLocked")] 
		public CBool IsLocked
		{
			get => GetProperty(ref _isLocked);
			set => SetProperty(ref _isLocked, value);
		}

		public gameLootContainerBasePS(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
