using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameStimuliMergeInfo : CVariable
	{
		private Vector4 _position;
		private wCHandle<gameObject> _instigator;
		private CFloat _radius;
		private CEnum<gamedataStimType> _type;
		private CEnum<gamedataStimPropagation> _propagationType;

		[Ordinal(0)] 
		[RED("position")] 
		public Vector4 Position
		{
			get => GetProperty(ref _position);
			set => SetProperty(ref _position, value);
		}

		[Ordinal(1)] 
		[RED("instigator")] 
		public wCHandle<gameObject> Instigator
		{
			get => GetProperty(ref _instigator);
			set => SetProperty(ref _instigator, value);
		}

		[Ordinal(2)] 
		[RED("radius")] 
		public CFloat Radius
		{
			get => GetProperty(ref _radius);
			set => SetProperty(ref _radius, value);
		}

		[Ordinal(3)] 
		[RED("type")] 
		public CEnum<gamedataStimType> Type
		{
			get => GetProperty(ref _type);
			set => SetProperty(ref _type, value);
		}

		[Ordinal(4)] 
		[RED("propagationType")] 
		public CEnum<gamedataStimPropagation> PropagationType
		{
			get => GetProperty(ref _propagationType);
			set => SetProperty(ref _propagationType, value);
		}

		public gameStimuliMergeInfo(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
