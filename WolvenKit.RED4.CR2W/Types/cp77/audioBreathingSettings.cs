using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class audioBreathingSettings : audioAudioMetadata
	{
		private CName _exhaustionRtpc;
		private CName _idleFadeOutRtpc;
		private CName _initialState;

		[Ordinal(1)] 
		[RED("exhaustionRtpc")] 
		public CName ExhaustionRtpc
		{
			get => GetProperty(ref _exhaustionRtpc);
			set => SetProperty(ref _exhaustionRtpc, value);
		}

		[Ordinal(2)] 
		[RED("idleFadeOutRtpc")] 
		public CName IdleFadeOutRtpc
		{
			get => GetProperty(ref _idleFadeOutRtpc);
			set => SetProperty(ref _idleFadeOutRtpc, value);
		}

		[Ordinal(3)] 
		[RED("initialState")] 
		public CName InitialState
		{
			get => GetProperty(ref _initialState);
			set => SetProperty(ref _initialState, value);
		}

		public audioBreathingSettings(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
