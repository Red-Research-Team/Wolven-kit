using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class entContextualLookAtAddEvent : entLookAtAddEvent
	{
		private CName _contextName;

		[Ordinal(4)] 
		[RED("contextName")] 
		public CName ContextName
		{
			get => GetProperty(ref _contextName);
			set => SetProperty(ref _contextName, value);
		}

		public entContextualLookAtAddEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
