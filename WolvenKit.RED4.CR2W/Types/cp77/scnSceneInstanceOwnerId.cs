using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class scnSceneInstanceOwnerId : CVariable
	{
		private CUInt64 _hash;

		[Ordinal(0)] 
		[RED("hash")] 
		public CUInt64 Hash
		{
			get
			{
				if (_hash == null)
				{
					_hash = (CUInt64) CR2WTypeManager.Create("Uint64", "hash", cr2w, this);
				}
				return _hash;
			}
			set
			{
				if (_hash == value)
				{
					return;
				}
				_hash = value;
				PropertySet(this);
			}
		}

		public scnSceneInstanceOwnerId(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
