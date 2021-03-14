using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimSetEntryAudioData : ISerializable
	{
		private CArray<CHandle<animAnimEvent>> _events;

		[Ordinal(0)] 
		[RED("events")] 
		public CArray<CHandle<animAnimEvent>> Events
		{
			get
			{
				if (_events == null)
				{
					_events = (CArray<CHandle<animAnimEvent>>) CR2WTypeManager.Create("array:handle:animAnimEvent", "events", cr2w, this);
				}
				return _events;
			}
			set
			{
				if (_events == value)
				{
					return;
				}
				_events = value;
				PropertySet(this);
			}
		}

		public animAnimSetEntryAudioData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
