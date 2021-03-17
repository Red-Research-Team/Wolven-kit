using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class ChangeLightEvent : redEvent
	{
		private ScriptLightSettings _settings;
		private CFloat _time;
		private CName _curve;
		private CBool _loop;

		[Ordinal(0)] 
		[RED("settings")] 
		public ScriptLightSettings Settings
		{
			get => GetProperty(ref _settings);
			set => SetProperty(ref _settings, value);
		}

		[Ordinal(1)] 
		[RED("time")] 
		public CFloat Time
		{
			get => GetProperty(ref _time);
			set => SetProperty(ref _time, value);
		}

		[Ordinal(2)] 
		[RED("curve")] 
		public CName Curve
		{
			get => GetProperty(ref _curve);
			set => SetProperty(ref _curve, value);
		}

		[Ordinal(3)] 
		[RED("loop")] 
		public CBool Loop
		{
			get => GetProperty(ref _loop);
			set => SetProperty(ref _loop, value);
		}

		public ChangeLightEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
