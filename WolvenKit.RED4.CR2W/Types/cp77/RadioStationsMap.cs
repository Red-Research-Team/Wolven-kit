using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class RadioStationsMap : CVariable
	{
		private CName _soundEvent;
		private CString _channelName;
		private CEnum<ERadioStationList> _stationID;

		[Ordinal(0)] 
		[RED("soundEvent")] 
		public CName SoundEvent
		{
			get => GetProperty(ref _soundEvent);
			set => SetProperty(ref _soundEvent, value);
		}

		[Ordinal(1)] 
		[RED("channelName")] 
		public CString ChannelName
		{
			get => GetProperty(ref _channelName);
			set => SetProperty(ref _channelName, value);
		}

		[Ordinal(2)] 
		[RED("stationID")] 
		public CEnum<ERadioStationList> StationID
		{
			get => GetProperty(ref _stationID);
			set => SetProperty(ref _stationID, value);
		}

		public RadioStationsMap(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
