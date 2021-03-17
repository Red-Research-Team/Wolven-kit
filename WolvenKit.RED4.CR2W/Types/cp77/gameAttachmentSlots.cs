using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameAttachmentSlots : entIComponent
	{
		private CArray<gameAnimParamSlotsOption> _animParams;

		[Ordinal(3)] 
		[RED("animParams")] 
		public CArray<gameAnimParamSlotsOption> AnimParams
		{
			get => GetProperty(ref _animParams);
			set => SetProperty(ref _animParams, value);
		}

		public gameAttachmentSlots(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
