using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class scnlocLocStoreEmbeddedVariantDescriptorEntry : CVariable
	{
		private scnlocVariantId _variantId;
		private scnlocLocstringId _locstringId;
		private CEnum<scnlocLocaleId> _localeId;
		private scnlocSignature _signature;
		private CUInt32 _vpeIndex;

		[Ordinal(0)] 
		[RED("variantId")] 
		public scnlocVariantId VariantId
		{
			get => GetProperty(ref _variantId);
			set => SetProperty(ref _variantId, value);
		}

		[Ordinal(1)] 
		[RED("locstringId")] 
		public scnlocLocstringId LocstringId
		{
			get => GetProperty(ref _locstringId);
			set => SetProperty(ref _locstringId, value);
		}

		[Ordinal(2)] 
		[RED("localeId")] 
		public CEnum<scnlocLocaleId> LocaleId
		{
			get => GetProperty(ref _localeId);
			set => SetProperty(ref _localeId, value);
		}

		[Ordinal(3)] 
		[RED("signature")] 
		public scnlocSignature Signature
		{
			get => GetProperty(ref _signature);
			set => SetProperty(ref _signature, value);
		}

		[Ordinal(4)] 
		[RED("vpeIndex")] 
		public CUInt32 VpeIndex
		{
			get => GetProperty(ref _vpeIndex);
			set => SetProperty(ref _vpeIndex, value);
		}

		public scnlocLocStoreEmbeddedVariantDescriptorEntry(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
