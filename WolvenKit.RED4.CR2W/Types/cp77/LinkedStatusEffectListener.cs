using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class LinkedStatusEffectListener : gameScriptStatusEffectListener
	{
		private wCHandle<gameObject> _instigatorObject;
		private TweakDBID _linkedEffect;
		private CHandle<RemoveLinkedStatusEffectsEvent> _evt;
		private CHandle<gameStatusEffect> _statusEffect;

		[Ordinal(0)] 
		[RED("instigatorObject")] 
		public wCHandle<gameObject> InstigatorObject
		{
			get => GetProperty(ref _instigatorObject);
			set => SetProperty(ref _instigatorObject, value);
		}

		[Ordinal(1)] 
		[RED("linkedEffect")] 
		public TweakDBID LinkedEffect
		{
			get => GetProperty(ref _linkedEffect);
			set => SetProperty(ref _linkedEffect, value);
		}

		[Ordinal(2)] 
		[RED("evt")] 
		public CHandle<RemoveLinkedStatusEffectsEvent> Evt
		{
			get => GetProperty(ref _evt);
			set => SetProperty(ref _evt, value);
		}

		[Ordinal(3)] 
		[RED("statusEffect")] 
		public CHandle<gameStatusEffect> StatusEffect
		{
			get => GetProperty(ref _statusEffect);
			set => SetProperty(ref _statusEffect, value);
		}

		public LinkedStatusEffectListener(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
