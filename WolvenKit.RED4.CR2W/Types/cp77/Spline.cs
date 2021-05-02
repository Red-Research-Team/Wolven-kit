using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class Spline : ISerializable
	{
		private CArray<SplinePoint> _points;
		private CBool _looped;
		private CBool _reversed;
		private CBool _hasDirection;

		[Ordinal(0)] 
		[RED("points")] 
		public CArray<SplinePoint> Points
		{
			get => GetProperty(ref _points);
			set => SetProperty(ref _points, value);
		}

		[Ordinal(1)] 
		[RED("looped")] 
		public CBool Looped
		{
			get => GetProperty(ref _looped);
			set => SetProperty(ref _looped, value);
		}

		[Ordinal(2)] 
		[RED("reversed")] 
		public CBool Reversed
		{
			get => GetProperty(ref _reversed);
			set => SetProperty(ref _reversed, value);
		}

		[Ordinal(3)] 
		[RED("hasDirection")] 
		public CBool HasDirection
		{
			get => GetProperty(ref _hasDirection);
			set => SetProperty(ref _hasDirection, value);
		}

		public Spline(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
