using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class ScriptedWeakspotObject : gameWeakspotObject
	{
		private WeakspotOnDestroyProperties _weakspotOnDestroyProperties;
		private CHandle<entMeshComponent> _mesh;
		private CHandle<gameinteractionsComponent> _interaction;
		private CHandle<entIPlacedComponent> _collider;
		private wCHandle<gameObject> _instigator;
		private WeakspotRecordData _weakspotRecordData;
		private CBool _alive;
		private CBool _hasBeenScanned;

		[Ordinal(40)] 
		[RED("weakspotOnDestroyProperties")] 
		public WeakspotOnDestroyProperties WeakspotOnDestroyProperties
		{
			get => GetProperty(ref _weakspotOnDestroyProperties);
			set => SetProperty(ref _weakspotOnDestroyProperties, value);
		}

		[Ordinal(41)] 
		[RED("mesh")] 
		public CHandle<entMeshComponent> Mesh
		{
			get => GetProperty(ref _mesh);
			set => SetProperty(ref _mesh, value);
		}

		[Ordinal(42)] 
		[RED("interaction")] 
		public CHandle<gameinteractionsComponent> Interaction
		{
			get => GetProperty(ref _interaction);
			set => SetProperty(ref _interaction, value);
		}

		[Ordinal(43)] 
		[RED("collider")] 
		public CHandle<entIPlacedComponent> Collider
		{
			get => GetProperty(ref _collider);
			set => SetProperty(ref _collider, value);
		}

		[Ordinal(44)] 
		[RED("instigator")] 
		public wCHandle<gameObject> Instigator
		{
			get => GetProperty(ref _instigator);
			set => SetProperty(ref _instigator, value);
		}

		[Ordinal(45)] 
		[RED("weakspotRecordData")] 
		public WeakspotRecordData WeakspotRecordData
		{
			get => GetProperty(ref _weakspotRecordData);
			set => SetProperty(ref _weakspotRecordData, value);
		}

		[Ordinal(46)] 
		[RED("alive")] 
		public CBool Alive
		{
			get => GetProperty(ref _alive);
			set => SetProperty(ref _alive, value);
		}

		[Ordinal(47)] 
		[RED("hasBeenScanned")] 
		public CBool HasBeenScanned
		{
			get => GetProperty(ref _hasBeenScanned);
			set => SetProperty(ref _hasBeenScanned, value);
		}

		public ScriptedWeakspotObject(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
