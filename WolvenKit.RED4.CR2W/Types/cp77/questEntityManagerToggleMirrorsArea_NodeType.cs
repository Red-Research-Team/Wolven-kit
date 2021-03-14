using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questEntityManagerToggleMirrorsArea_NodeType : questIEntityManager_NodeType
	{
		private gameEntityReference _objectRef;
		private CBool _isInMirrorsArea;

		[Ordinal(0)] 
		[RED("objectRef")] 
		public gameEntityReference ObjectRef
		{
			get
			{
				if (_objectRef == null)
				{
					_objectRef = (gameEntityReference) CR2WTypeManager.Create("gameEntityReference", "objectRef", cr2w, this);
				}
				return _objectRef;
			}
			set
			{
				if (_objectRef == value)
				{
					return;
				}
				_objectRef = value;
				PropertySet(this);
			}
		}

		[Ordinal(1)] 
		[RED("isInMirrorsArea")] 
		public CBool IsInMirrorsArea
		{
			get
			{
				if (_isInMirrorsArea == null)
				{
					_isInMirrorsArea = (CBool) CR2WTypeManager.Create("Bool", "isInMirrorsArea", cr2w, this);
				}
				return _isInMirrorsArea;
			}
			set
			{
				if (_isInMirrorsArea == value)
				{
					return;
				}
				_isInMirrorsArea = value;
				PropertySet(this);
			}
		}

		public questEntityManagerToggleMirrorsArea_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
