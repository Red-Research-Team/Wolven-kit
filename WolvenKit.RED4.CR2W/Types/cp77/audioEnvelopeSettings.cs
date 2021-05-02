using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class audioEnvelopeSettings : audioAudioMetadata
	{
		private CFloat _attackTime;
		private CFloat _releaseTime;
		private CFloat _holdTime;

		[Ordinal(1)] 
		[RED("attackTime")] 
		public CFloat AttackTime
		{
			get => GetProperty(ref _attackTime);
			set => SetProperty(ref _attackTime, value);
		}

		[Ordinal(2)] 
		[RED("releaseTime")] 
		public CFloat ReleaseTime
		{
			get => GetProperty(ref _releaseTime);
			set => SetProperty(ref _releaseTime, value);
		}

		[Ordinal(3)] 
		[RED("holdTime")] 
		public CFloat HoldTime
		{
			get => GetProperty(ref _holdTime);
			set => SetProperty(ref _holdTime, value);
		}

		public audioEnvelopeSettings(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
