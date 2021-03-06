using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameinteractionsCAabbDefinition : gameinteractionsIShapeDefinition
	{
		private Vector4 _min;
		private Vector4 _max;

		[Ordinal(0)] 
		[RED("min")] 
		public Vector4 Min
		{
			get => GetProperty(ref _min);
			set => SetProperty(ref _min, value);
		}

		[Ordinal(1)] 
		[RED("max")] 
		public Vector4 Max
		{
			get => GetProperty(ref _max);
			set => SetProperty(ref _max, value);
		}

		public gameinteractionsCAabbDefinition(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
