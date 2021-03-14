using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class Point : CVariable
	{
		private CInt32 _x;
		private CInt32 _y;

		[Ordinal(0)] 
		[RED("x")] 
		public CInt32 X
		{
			get
			{
				if (_x == null)
				{
					_x = (CInt32) CR2WTypeManager.Create("Int32", "x", cr2w, this);
				}
				return _x;
			}
			set
			{
				if (_x == value)
				{
					return;
				}
				_x = value;
				PropertySet(this);
			}
		}

		[Ordinal(1)] 
		[RED("y")] 
		public CInt32 Y
		{
			get
			{
				if (_y == null)
				{
					_y = (CInt32) CR2WTypeManager.Create("Int32", "y", cr2w, this);
				}
				return _y;
			}
			set
			{
				if (_y == value)
				{
					return;
				}
				_y = value;
				PropertySet(this);
			}
		}

		public Point(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
