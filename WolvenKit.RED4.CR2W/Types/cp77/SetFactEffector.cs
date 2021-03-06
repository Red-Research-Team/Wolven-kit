using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class SetFactEffector : gameEffector
	{
		private CName _fact;
		private CInt32 _value;

		[Ordinal(0)] 
		[RED("fact")] 
		public CName Fact
		{
			get => GetProperty(ref _fact);
			set => SetProperty(ref _fact, value);
		}

		[Ordinal(1)] 
		[RED("value")] 
		public CInt32 Value
		{
			get => GetProperty(ref _value);
			set => SetProperty(ref _value, value);
		}

		public SetFactEffector(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
