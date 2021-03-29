using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class IdentifiedWrappedTooltipData : ATooltipData
	{
		private CName _identifier;
		private entEntityID _tooltipOwner;
		private CHandle<ATooltipData> _data;

		[Ordinal(0)] 
		[RED("identifier")] 
		public CName Identifier
		{
			get => GetProperty(ref _identifier);
			set => SetProperty(ref _identifier, value);
		}

		[Ordinal(1)] 
		[RED("tooltipOwner")] 
		public entEntityID TooltipOwner
		{
			get => GetProperty(ref _tooltipOwner);
			set => SetProperty(ref _tooltipOwner, value);
		}

		[Ordinal(2)] 
		[RED("data")] 
		public CHandle<ATooltipData> Data
		{
			get => GetProperty(ref _data);
			set => SetProperty(ref _data, value);
		}

		public IdentifiedWrappedTooltipData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
