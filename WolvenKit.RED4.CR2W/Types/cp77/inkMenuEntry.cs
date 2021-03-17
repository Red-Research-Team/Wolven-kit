using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class inkMenuEntry : CVariable
	{
		private CName _name;
		private rRef<inkWidgetLibraryResource> _menuWidget;
		private CUInt32 _depth;
		private CEnum<inkSpawnMode> _spawnMode;
		private CBool _isAffectedByFadeout;

		[Ordinal(0)] 
		[RED("name")] 
		public CName Name
		{
			get => GetProperty(ref _name);
			set => SetProperty(ref _name, value);
		}

		[Ordinal(1)] 
		[RED("menuWidget")] 
		public rRef<inkWidgetLibraryResource> MenuWidget
		{
			get => GetProperty(ref _menuWidget);
			set => SetProperty(ref _menuWidget, value);
		}

		[Ordinal(2)] 
		[RED("depth")] 
		public CUInt32 Depth
		{
			get => GetProperty(ref _depth);
			set => SetProperty(ref _depth, value);
		}

		[Ordinal(3)] 
		[RED("spawnMode")] 
		public CEnum<inkSpawnMode> SpawnMode
		{
			get => GetProperty(ref _spawnMode);
			set => SetProperty(ref _spawnMode, value);
		}

		[Ordinal(4)] 
		[RED("isAffectedByFadeout")] 
		public CBool IsAffectedByFadeout
		{
			get => GetProperty(ref _isAffectedByFadeout);
			set => SetProperty(ref _isAffectedByFadeout, value);
		}

		public inkMenuEntry(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
