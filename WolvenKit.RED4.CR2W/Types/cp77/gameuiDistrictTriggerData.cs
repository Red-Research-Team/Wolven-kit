using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameuiDistrictTriggerData : CVariable
	{
		private CEnum<gamedataDistrict> _district;
		private CName _triggerName;

		[Ordinal(0)] 
		[RED("district")] 
		public CEnum<gamedataDistrict> District
		{
			get => GetProperty(ref _district);
			set => SetProperty(ref _district, value);
		}

		[Ordinal(1)] 
		[RED("triggerName")] 
		public CName TriggerName
		{
			get => GetProperty(ref _triggerName);
			set => SetProperty(ref _triggerName, value);
		}

		public gameuiDistrictTriggerData(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
