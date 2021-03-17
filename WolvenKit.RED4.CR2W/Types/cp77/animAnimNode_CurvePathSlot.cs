using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimNode_CurvePathSlot : animAnimNode_Base
	{
		private animPoseLink _input;

		[Ordinal(11)] 
		[RED("input")] 
		public animPoseLink Input
		{
			get => GetProperty(ref _input);
			set => SetProperty(ref _input, value);
		}

		public animAnimNode_CurvePathSlot(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
