using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class garmentMeshParamGarment : meshMeshParameter
	{
		private CArray<garmentMeshParamGarmentChunkData> _chunks;

		[Ordinal(0)] 
		[RED("chunks")] 
		public CArray<garmentMeshParamGarmentChunkData> Chunks
		{
			get
			{
				if (_chunks == null)
				{
					_chunks = (CArray<garmentMeshParamGarmentChunkData>) CR2WTypeManager.Create("array:garmentMeshParamGarmentChunkData", "chunks", cr2w, this);
				}
				return _chunks;
			}
			set
			{
				if (_chunks == value)
				{
					return;
				}
				_chunks = value;
				PropertySet(this);
			}
		}

		public garmentMeshParamGarment(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
