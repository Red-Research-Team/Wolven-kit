using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animHipsIkRequest : CVariable
	{
		private CName _leftLegIkChain;
		private CName _rightLegIkChain;
		private animTransformIndex _hipsTransformIndex;
		private animTransformIndex _leftFootTransformIndex;
		private animTransformIndex _rightFootTransformIndex;

		[Ordinal(0)] 
		[RED("leftLegIkChain")] 
		public CName LeftLegIkChain
		{
			get => GetProperty(ref _leftLegIkChain);
			set => SetProperty(ref _leftLegIkChain, value);
		}

		[Ordinal(1)] 
		[RED("rightLegIkChain")] 
		public CName RightLegIkChain
		{
			get => GetProperty(ref _rightLegIkChain);
			set => SetProperty(ref _rightLegIkChain, value);
		}

		[Ordinal(2)] 
		[RED("hipsTransformIndex")] 
		public animTransformIndex HipsTransformIndex
		{
			get => GetProperty(ref _hipsTransformIndex);
			set => SetProperty(ref _hipsTransformIndex, value);
		}

		[Ordinal(3)] 
		[RED("leftFootTransformIndex")] 
		public animTransformIndex LeftFootTransformIndex
		{
			get => GetProperty(ref _leftFootTransformIndex);
			set => SetProperty(ref _leftFootTransformIndex, value);
		}

		[Ordinal(4)] 
		[RED("rightFootTransformIndex")] 
		public animTransformIndex RightFootTransformIndex
		{
			get => GetProperty(ref _rightFootTransformIndex);
			set => SetProperty(ref _rightFootTransformIndex, value);
		}

		public animHipsIkRequest(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
