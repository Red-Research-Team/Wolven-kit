using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameEffectTriggerEffectDesc : ISerializable
	{
		private raRef<worldEffect> _effect;
		private CEnum<gameEffectTriggerPositioningType> _positionType;
		private CEnum<gameEffectTriggerRotationType> _rotationType;
		private Vector3 _offset;
		private CUInt32 _playFromHour;
		private CUInt32 _playTillHour;

		[Ordinal(0)] 
		[RED("effect")] 
		public raRef<worldEffect> Effect
		{
			get => GetProperty(ref _effect);
			set => SetProperty(ref _effect, value);
		}

		[Ordinal(1)] 
		[RED("positionType")] 
		public CEnum<gameEffectTriggerPositioningType> PositionType
		{
			get => GetProperty(ref _positionType);
			set => SetProperty(ref _positionType, value);
		}

		[Ordinal(2)] 
		[RED("rotationType")] 
		public CEnum<gameEffectTriggerRotationType> RotationType
		{
			get => GetProperty(ref _rotationType);
			set => SetProperty(ref _rotationType, value);
		}

		[Ordinal(3)] 
		[RED("offset")] 
		public Vector3 Offset
		{
			get => GetProperty(ref _offset);
			set => SetProperty(ref _offset, value);
		}

		[Ordinal(4)] 
		[RED("playFromHour")] 
		public CUInt32 PlayFromHour
		{
			get => GetProperty(ref _playFromHour);
			set => SetProperty(ref _playFromHour, value);
		}

		[Ordinal(5)] 
		[RED("playTillHour")] 
		public CUInt32 PlayTillHour
		{
			get => GetProperty(ref _playTillHour);
			set => SetProperty(ref _playTillHour, value);
		}

		public gameEffectTriggerEffectDesc(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
