using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class meshMeshParamCloth_Graphical : meshMeshParameter
	{
		private CArray<CArray<CUInt16>> _lodChunkIndices;
		private CArray<meshGfxClothChunkData> _chunks;
		private CArray<CArray<CArray<CUInt16>>> _latchers;

		[Ordinal(0)] 
		[RED("lodChunkIndices")] 
		public CArray<CArray<CUInt16>> LodChunkIndices
		{
			get => GetProperty(ref _lodChunkIndices);
			set => SetProperty(ref _lodChunkIndices, value);
		}

		[Ordinal(1)] 
		[RED("chunks")] 
		public CArray<meshGfxClothChunkData> Chunks
		{
			get => GetProperty(ref _chunks);
			set => SetProperty(ref _chunks, value);
		}

		[Ordinal(2)] 
		[RED("latchers")] 
		public CArray<CArray<CArray<CUInt16>>> Latchers
		{
			get => GetProperty(ref _latchers);
			set => SetProperty(ref _latchers, value);
		}

		public meshMeshParamCloth_Graphical(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
