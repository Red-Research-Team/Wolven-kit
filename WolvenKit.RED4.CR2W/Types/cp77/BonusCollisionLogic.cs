using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class BonusCollisionLogic : gameuiSideScrollerMiniGameCollisionLogic
	{
		private CBool _hasTriggered;

		[Ordinal(3)] 
		[RED("hasTriggered")] 
		public CBool HasTriggered
		{
			get
			{
				if (_hasTriggered == null)
				{
					_hasTriggered = (CBool) CR2WTypeManager.Create("Bool", "hasTriggered", cr2w, this);
				}
				return _hasTriggered;
			}
			set
			{
				if (_hasTriggered == value)
				{
					return;
				}
				_hasTriggered = value;
				PropertySet(this);
			}
		}

		public BonusCollisionLogic(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
