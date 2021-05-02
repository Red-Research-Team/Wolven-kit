using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class rendGridGeneratorData : CVariable
	{
		private Vector3 _startingPosition;
		private EulerAngles _rotation;
		private CFloat _xStep;
		private CFloat _yStep;
		private CUInt32 _numberOfXSteps;
		private CUInt32 _numberOfYSteps;
		private CFloat _orbitDistance;
		private CFloat _zoom;

		[Ordinal(0)] 
		[RED("startingPosition")] 
		public Vector3 StartingPosition
		{
			get => GetProperty(ref _startingPosition);
			set => SetProperty(ref _startingPosition, value);
		}

		[Ordinal(1)] 
		[RED("rotation")] 
		public EulerAngles Rotation
		{
			get => GetProperty(ref _rotation);
			set => SetProperty(ref _rotation, value);
		}

		[Ordinal(2)] 
		[RED("xStep")] 
		public CFloat XStep
		{
			get => GetProperty(ref _xStep);
			set => SetProperty(ref _xStep, value);
		}

		[Ordinal(3)] 
		[RED("yStep")] 
		public CFloat YStep
		{
			get => GetProperty(ref _yStep);
			set => SetProperty(ref _yStep, value);
		}

		[Ordinal(4)] 
		[RED("numberOfXSteps")] 
		public CUInt32 NumberOfXSteps
		{
			get => GetProperty(ref _numberOfXSteps);
			set => SetProperty(ref _numberOfXSteps, value);
		}

		[Ordinal(5)] 
		[RED("numberOfYSteps")] 
		public CUInt32 NumberOfYSteps
		{
			get => GetProperty(ref _numberOfYSteps);
			set => SetProperty(ref _numberOfYSteps, value);
		}

		[Ordinal(6)] 
		[RED("orbitDistance")] 
		public CFloat OrbitDistance
		{
			get => GetProperty(ref _orbitDistance);
			set => SetProperty(ref _orbitDistance, value);
		}

		[Ordinal(7)] 
		[RED("zoom")] 
		public CFloat Zoom
		{
			get => GetProperty(ref _zoom);
			set => SetProperty(ref _zoom, value);
		}

		public rendGridGeneratorData(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
