using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class UI_NameplateDataDef : gamebbScriptDefinition
	{
		private gamebbScriptID_Variant _entityID;
		private gamebbScriptID_Bool _isVisible;
		private gamebbScriptID_Float _heightOffset;
		private gamebbScriptID_Int32 _damageProjection;

		[Ordinal(0)] 
		[RED("EntityID")] 
		public gamebbScriptID_Variant EntityID
		{
			get => GetProperty(ref _entityID);
			set => SetProperty(ref _entityID, value);
		}

		[Ordinal(1)] 
		[RED("IsVisible")] 
		public gamebbScriptID_Bool IsVisible
		{
			get => GetProperty(ref _isVisible);
			set => SetProperty(ref _isVisible, value);
		}

		[Ordinal(2)] 
		[RED("HeightOffset")] 
		public gamebbScriptID_Float HeightOffset
		{
			get => GetProperty(ref _heightOffset);
			set => SetProperty(ref _heightOffset, value);
		}

		[Ordinal(3)] 
		[RED("DamageProjection")] 
		public gamebbScriptID_Int32 DamageProjection
		{
			get => GetProperty(ref _damageProjection);
			set => SetProperty(ref _damageProjection, value);
		}

		public UI_NameplateDataDef(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
