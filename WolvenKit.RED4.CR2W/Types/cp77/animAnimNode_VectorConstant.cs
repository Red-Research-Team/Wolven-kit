using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimNode_VectorConstant : animAnimNode_VectorValue
	{
		private Vector4 _value;

		[Ordinal(11)] 
		[RED("value")] 
		public Vector4 Value
		{
			get
			{
				if (_value == null)
				{
					_value = (Vector4) CR2WTypeManager.Create("Vector4", "value", cr2w, this);
				}
				return _value;
			}
			set
			{
				if (_value == value)
				{
					return;
				}
				_value = value;
				PropertySet(this);
			}
		}

		public animAnimNode_VectorConstant(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
