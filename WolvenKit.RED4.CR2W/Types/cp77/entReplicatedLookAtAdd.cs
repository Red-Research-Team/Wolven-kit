using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class entReplicatedLookAtAdd : entReplicatedLookAtData
	{
		private CName _bodyPart;
		private animLookAtRequest _request;
		private CHandle<entIPositionProvider> _targetPositionProvider;
		private animLookAtRef _ref;

		[Ordinal(1)] 
		[RED("bodyPart")] 
		public CName BodyPart
		{
			get => GetProperty(ref _bodyPart);
			set => SetProperty(ref _bodyPart, value);
		}

		[Ordinal(2)] 
		[RED("request")] 
		public animLookAtRequest Request
		{
			get => GetProperty(ref _request);
			set => SetProperty(ref _request, value);
		}

		[Ordinal(3)] 
		[RED("targetPositionProvider")] 
		public CHandle<entIPositionProvider> TargetPositionProvider
		{
			get => GetProperty(ref _targetPositionProvider);
			set => SetProperty(ref _targetPositionProvider, value);
		}

		[Ordinal(4)] 
		[RED("ref")] 
		public animLookAtRef Ref
		{
			get => GetProperty(ref _ref);
			set => SetProperty(ref _ref, value);
		}

		public entReplicatedLookAtAdd(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
