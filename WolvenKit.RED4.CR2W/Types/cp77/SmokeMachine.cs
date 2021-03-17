using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class SmokeMachine : BasicDistractionDevice
	{
		private CHandle<gameStaticTriggerAreaComponent> _areaComponent;
		private CBool _highLightActive;
		private CArray<wCHandle<entEntity>> _entities;

		[Ordinal(99)] 
		[RED("areaComponent")] 
		public CHandle<gameStaticTriggerAreaComponent> AreaComponent
		{
			get => GetProperty(ref _areaComponent);
			set => SetProperty(ref _areaComponent, value);
		}

		[Ordinal(100)] 
		[RED("highLightActive")] 
		public CBool HighLightActive
		{
			get => GetProperty(ref _highLightActive);
			set => SetProperty(ref _highLightActive, value);
		}

		[Ordinal(101)] 
		[RED("entities")] 
		public CArray<wCHandle<entEntity>> Entities
		{
			get => GetProperty(ref _entities);
			set => SetProperty(ref _entities, value);
		}

		public SmokeMachine(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
