using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class SceneScreenUIAnimationsData : IScriptable
	{
		private CHandle<WidgetAnimationManager> _customAnimations;
		private CArray<CName> _onSpawnAnimations;
		private CName _defaultLibraryItemName;
		private CEnum<inkEAnchor> _defaultLibraryItemAnchor;

		[Ordinal(0)] 
		[RED("customAnimations")] 
		public CHandle<WidgetAnimationManager> CustomAnimations
		{
			get => GetProperty(ref _customAnimations);
			set => SetProperty(ref _customAnimations, value);
		}

		[Ordinal(1)] 
		[RED("onSpawnAnimations")] 
		public CArray<CName> OnSpawnAnimations
		{
			get => GetProperty(ref _onSpawnAnimations);
			set => SetProperty(ref _onSpawnAnimations, value);
		}

		[Ordinal(2)] 
		[RED("defaultLibraryItemName")] 
		public CName DefaultLibraryItemName
		{
			get => GetProperty(ref _defaultLibraryItemName);
			set => SetProperty(ref _defaultLibraryItemName, value);
		}

		[Ordinal(3)] 
		[RED("defaultLibraryItemAnchor")] 
		public CEnum<inkEAnchor> DefaultLibraryItemAnchor
		{
			get => GetProperty(ref _defaultLibraryItemAnchor);
			set => SetProperty(ref _defaultLibraryItemAnchor, value);
		}

		public SceneScreenUIAnimationsData(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
