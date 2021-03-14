using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questContentTokenManager_NodeType : questIGameManagerNonSignalStoppingNodeType
	{
		private CHandle<questIContentTokenManager_NodeSubType> _subtype;

		[Ordinal(0)] 
		[RED("subtype")] 
		public CHandle<questIContentTokenManager_NodeSubType> Subtype
		{
			get
			{
				if (_subtype == null)
				{
					_subtype = (CHandle<questIContentTokenManager_NodeSubType>) CR2WTypeManager.Create("handle:questIContentTokenManager_NodeSubType", "subtype", cr2w, this);
				}
				return _subtype;
			}
			set
			{
				if (_subtype == value)
				{
					return;
				}
				_subtype = value;
				PropertySet(this);
			}
		}

		public questContentTokenManager_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
