using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameaudioeventsVoiceEvent : redEvent
	{
		private CName _eventName;
		private CEnum<audioVoGruntType> _gruntType;
		private CEnum<audioVoGruntInterruptMode> _gruntInterruptMode;
		private CBool _isV;

		[Ordinal(0)] 
		[RED("eventName")] 
		public CName EventName
		{
			get => GetProperty(ref _eventName);
			set => SetProperty(ref _eventName, value);
		}

		[Ordinal(1)] 
		[RED("gruntType")] 
		public CEnum<audioVoGruntType> GruntType
		{
			get => GetProperty(ref _gruntType);
			set => SetProperty(ref _gruntType, value);
		}

		[Ordinal(2)] 
		[RED("gruntInterruptMode")] 
		public CEnum<audioVoGruntInterruptMode> GruntInterruptMode
		{
			get => GetProperty(ref _gruntInterruptMode);
			set => SetProperty(ref _gruntInterruptMode, value);
		}

		[Ordinal(3)] 
		[RED("isV")] 
		public CBool IsV
		{
			get => GetProperty(ref _isV);
			set => SetProperty(ref _isV, value);
		}

		public gameaudioeventsVoiceEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
