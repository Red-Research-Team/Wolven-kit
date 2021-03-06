using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class StimEventData : CVariable
	{
		private wCHandle<gameObject> _source;
		private CEnum<gamedataStimType> _stimType;

		[Ordinal(0)] 
		[RED("source")] 
		public wCHandle<gameObject> Source
		{
			get => GetProperty(ref _source);
			set => SetProperty(ref _source, value);
		}

		[Ordinal(1)] 
		[RED("stimType")] 
		public CEnum<gamedataStimType> StimType
		{
			get => GetProperty(ref _stimType);
			set => SetProperty(ref _stimType, value);
		}

		public StimEventData(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
