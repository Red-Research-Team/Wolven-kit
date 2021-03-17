using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimFeature_HitReactions : animAnimFeature
	{
		private Vector4 _hitDirection;
		private CFloat _hitIntensity;
		private CInt32 _hitType;
		private CInt32 _hitBodyPart;

		[Ordinal(0)] 
		[RED("hitDirection")] 
		public Vector4 HitDirection
		{
			get => GetProperty(ref _hitDirection);
			set => SetProperty(ref _hitDirection, value);
		}

		[Ordinal(1)] 
		[RED("hitIntensity")] 
		public CFloat HitIntensity
		{
			get => GetProperty(ref _hitIntensity);
			set => SetProperty(ref _hitIntensity, value);
		}

		[Ordinal(2)] 
		[RED("hitType")] 
		public CInt32 HitType
		{
			get => GetProperty(ref _hitType);
			set => SetProperty(ref _hitType, value);
		}

		[Ordinal(3)] 
		[RED("hitBodyPart")] 
		public CInt32 HitBodyPart
		{
			get => GetProperty(ref _hitBodyPart);
			set => SetProperty(ref _hitBodyPart, value);
		}

		public animAnimFeature_HitReactions(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
