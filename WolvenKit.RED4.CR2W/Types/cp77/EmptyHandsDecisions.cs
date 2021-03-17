using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class EmptyHandsDecisions : UpperBodyTransition
	{
		private CBool _stateBodyDone;

		[Ordinal(0)] 
		[RED("stateBodyDone")] 
		public CBool StateBodyDone
		{
			get => GetProperty(ref _stateBodyDone);
			set => SetProperty(ref _stateBodyDone, value);
		}

		public EmptyHandsDecisions(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
