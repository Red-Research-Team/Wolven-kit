using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class RegisterToListListener : gameScriptableSystemRequest
	{
		private wCHandle<gameObject> _object;
		private CName _funcName;

		[Ordinal(0)] 
		[RED("object")] 
		public wCHandle<gameObject> Object
		{
			get
			{
				if (_object == null)
				{
					_object = (wCHandle<gameObject>) CR2WTypeManager.Create("whandle:gameObject", "object", cr2w, this);
				}
				return _object;
			}
			set
			{
				if (_object == value)
				{
					return;
				}
				_object = value;
				PropertySet(this);
			}
		}

		[Ordinal(1)] 
		[RED("funcName")] 
		public CName FuncName
		{
			get
			{
				if (_funcName == null)
				{
					_funcName = (CName) CR2WTypeManager.Create("CName", "funcName", cr2w, this);
				}
				return _funcName;
			}
			set
			{
				if (_funcName == value)
				{
					return;
				}
				_funcName = value;
				PropertySet(this);
			}
		}

		public RegisterToListListener(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
