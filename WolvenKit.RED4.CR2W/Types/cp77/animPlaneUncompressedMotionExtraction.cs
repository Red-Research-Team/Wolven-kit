using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animPlaneUncompressedMotionExtraction : animIMotionExtraction
	{
		private CArray<Vector3> _frames;
		private CFloat _duration;

		[Ordinal(0)] 
		[RED("frames")] 
		public CArray<Vector3> Frames
		{
			get => GetProperty(ref _frames);
			set => SetProperty(ref _frames, value);
		}

		[Ordinal(1)] 
		[RED("duration")] 
		public CFloat Duration
		{
			get => GetProperty(ref _duration);
			set => SetProperty(ref _duration, value);
		}

		public animPlaneUncompressedMotionExtraction(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
