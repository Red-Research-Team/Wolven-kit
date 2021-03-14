using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class scnCommunityParams : CVariable
	{
		private NodeRef _reference;
		private CName _entryName;
		private CBool _forceMaxVisibility;

		[Ordinal(0)] 
		[RED("reference")] 
		public NodeRef Reference
		{
			get
			{
				if (_reference == null)
				{
					_reference = (NodeRef) CR2WTypeManager.Create("NodeRef", "reference", cr2w, this);
				}
				return _reference;
			}
			set
			{
				if (_reference == value)
				{
					return;
				}
				_reference = value;
				PropertySet(this);
			}
		}

		[Ordinal(1)] 
		[RED("entryName")] 
		public CName EntryName
		{
			get
			{
				if (_entryName == null)
				{
					_entryName = (CName) CR2WTypeManager.Create("CName", "entryName", cr2w, this);
				}
				return _entryName;
			}
			set
			{
				if (_entryName == value)
				{
					return;
				}
				_entryName = value;
				PropertySet(this);
			}
		}

		[Ordinal(2)] 
		[RED("forceMaxVisibility")] 
		public CBool ForceMaxVisibility
		{
			get
			{
				if (_forceMaxVisibility == null)
				{
					_forceMaxVisibility = (CBool) CR2WTypeManager.Create("Bool", "forceMaxVisibility", cr2w, this);
				}
				return _forceMaxVisibility;
			}
			set
			{
				if (_forceMaxVisibility == value)
				{
					return;
				}
				_forceMaxVisibility = value;
				PropertySet(this);
			}
		}

		public scnCommunityParams(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
