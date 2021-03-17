using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameinteractionsInteractionEvent : redEvent
	{
		private wCHandle<gameObject> _hotspot;
		private wCHandle<gameObject> _activator;
		private CEnum<gameinteractionsEInteractionEventType> _eventType;
		private gameinteractionsLayerData _layerData;

		[Ordinal(0)] 
		[RED("hotspot")] 
		public wCHandle<gameObject> Hotspot
		{
			get => GetProperty(ref _hotspot);
			set => SetProperty(ref _hotspot, value);
		}

		[Ordinal(1)] 
		[RED("activator")] 
		public wCHandle<gameObject> Activator
		{
			get => GetProperty(ref _activator);
			set => SetProperty(ref _activator, value);
		}

		[Ordinal(2)] 
		[RED("eventType")] 
		public CEnum<gameinteractionsEInteractionEventType> EventType
		{
			get => GetProperty(ref _eventType);
			set => SetProperty(ref _eventType, value);
		}

		[Ordinal(3)] 
		[RED("layerData")] 
		public gameinteractionsLayerData LayerData
		{
			get => GetProperty(ref _layerData);
			set => SetProperty(ref _layerData, value);
		}

		public gameinteractionsInteractionEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
