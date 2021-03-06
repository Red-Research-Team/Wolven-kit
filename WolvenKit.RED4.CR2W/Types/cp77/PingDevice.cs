using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class PingDevice : ActionBool
	{
		private CBool _shouldForward;

		[Ordinal(25)] 
		[RED("shouldForward")] 
		public CBool ShouldForward
		{
			get => GetProperty(ref _shouldForward);
			set => SetProperty(ref _shouldForward, value);
		}

		public PingDevice(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
