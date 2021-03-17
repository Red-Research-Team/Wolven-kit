using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class CPOMissionPlayerVotedEvent : redEvent
	{
		private CName _compatibleDeviceName;

		[Ordinal(0)] 
		[RED("compatibleDeviceName")] 
		public CName CompatibleDeviceName
		{
			get => GetProperty(ref _compatibleDeviceName);
			set => SetProperty(ref _compatibleDeviceName, value);
		}

		public CPOMissionPlayerVotedEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
