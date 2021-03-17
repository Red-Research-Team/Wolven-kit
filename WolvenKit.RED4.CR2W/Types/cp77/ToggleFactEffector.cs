using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class ToggleFactEffector : gameEffector
	{
		private CName _fact;
		private CInt32 _valueOn;
		private CInt32 _valueOff;

		[Ordinal(0)] 
		[RED("fact")] 
		public CName Fact
		{
			get => GetProperty(ref _fact);
			set => SetProperty(ref _fact, value);
		}

		[Ordinal(1)] 
		[RED("valueOn")] 
		public CInt32 ValueOn
		{
			get => GetProperty(ref _valueOn);
			set => SetProperty(ref _valueOn, value);
		}

		[Ordinal(2)] 
		[RED("valueOff")] 
		public CInt32 ValueOff
		{
			get => GetProperty(ref _valueOff);
			set => SetProperty(ref _valueOff, value);
		}

		public ToggleFactEffector(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
