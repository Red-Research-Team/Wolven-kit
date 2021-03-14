using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class cpSplinePlacementProvider_Count : cpSplinePlacementProvider_Distance
	{
		private CUInt32 _count;

		[Ordinal(1)] 
		[RED("count")] 
		public CUInt32 Count
		{
			get
			{
				if (_count == null)
				{
					_count = (CUInt32) CR2WTypeManager.Create("Uint32", "count", cr2w, this);
				}
				return _count;
			}
			set
			{
				if (_count == value)
				{
					return;
				}
				_count = value;
				PropertySet(this);
			}
		}

		public cpSplinePlacementProvider_Count(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
