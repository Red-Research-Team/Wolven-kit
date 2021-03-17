using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameTier3CameraSettings : CVariable
	{
		private CFloat _yawLeftLimit;
		private CFloat _yawRightLimit;
		private CFloat _pitchTopLimit;
		private CFloat _pitchBottomLimit;
		private CFloat _pitchSpeedMultiplier;
		private CFloat _yawSpeedMultiplier;

		[Ordinal(0)] 
		[RED("yawLeftLimit")] 
		public CFloat YawLeftLimit
		{
			get => GetProperty(ref _yawLeftLimit);
			set => SetProperty(ref _yawLeftLimit, value);
		}

		[Ordinal(1)] 
		[RED("yawRightLimit")] 
		public CFloat YawRightLimit
		{
			get => GetProperty(ref _yawRightLimit);
			set => SetProperty(ref _yawRightLimit, value);
		}

		[Ordinal(2)] 
		[RED("pitchTopLimit")] 
		public CFloat PitchTopLimit
		{
			get => GetProperty(ref _pitchTopLimit);
			set => SetProperty(ref _pitchTopLimit, value);
		}

		[Ordinal(3)] 
		[RED("pitchBottomLimit")] 
		public CFloat PitchBottomLimit
		{
			get => GetProperty(ref _pitchBottomLimit);
			set => SetProperty(ref _pitchBottomLimit, value);
		}

		[Ordinal(4)] 
		[RED("pitchSpeedMultiplier")] 
		public CFloat PitchSpeedMultiplier
		{
			get => GetProperty(ref _pitchSpeedMultiplier);
			set => SetProperty(ref _pitchSpeedMultiplier, value);
		}

		[Ordinal(5)] 
		[RED("yawSpeedMultiplier")] 
		public CFloat YawSpeedMultiplier
		{
			get => GetProperty(ref _yawSpeedMultiplier);
			set => SetProperty(ref _yawSpeedMultiplier, value);
		}

		public gameTier3CameraSettings(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
