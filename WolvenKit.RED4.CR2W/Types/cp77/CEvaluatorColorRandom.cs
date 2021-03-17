using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class CEvaluatorColorRandom : IEvaluatorColor
	{
		private CColor _min;
		private CColor _max;
		private CBool _randomPerChannel;

		[Ordinal(0)] 
		[RED("min")] 
		public CColor Min
		{
			get => GetProperty(ref _min);
			set => SetProperty(ref _min, value);
		}

		[Ordinal(1)] 
		[RED("max")] 
		public CColor Max
		{
			get => GetProperty(ref _max);
			set => SetProperty(ref _max, value);
		}

		[Ordinal(2)] 
		[RED("randomPerChannel")] 
		public CBool RandomPerChannel
		{
			get => GetProperty(ref _randomPerChannel);
			set => SetProperty(ref _randomPerChannel, value);
		}

		public CEvaluatorColorRandom(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
