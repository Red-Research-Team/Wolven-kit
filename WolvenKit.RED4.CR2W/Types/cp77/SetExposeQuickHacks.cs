using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class SetExposeQuickHacks : ActionBool
	{
		private CBool _isRemote;

		[Ordinal(25)] 
		[RED("isRemote")] 
		public CBool IsRemote
		{
			get
			{
				if (_isRemote == null)
				{
					_isRemote = (CBool) CR2WTypeManager.Create("Bool", "isRemote", cr2w, this);
				}
				return _isRemote;
			}
			set
			{
				if (_isRemote == value)
				{
					return;
				}
				_isRemote = value;
				PropertySet(this);
			}
		}

		public SetExposeQuickHacks(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
