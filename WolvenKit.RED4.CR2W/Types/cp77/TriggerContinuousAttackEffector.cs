using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class TriggerContinuousAttackEffector : gameContinuousEffector
	{
		private wCHandle<gameObject> _owner;
		private TweakDBID _attackTDBID;

		[Ordinal(0)] 
		[RED("owner")] 
		public wCHandle<gameObject> Owner
		{
			get
			{
				if (_owner == null)
				{
					_owner = (wCHandle<gameObject>) CR2WTypeManager.Create("whandle:gameObject", "owner", cr2w, this);
				}
				return _owner;
			}
			set
			{
				if (_owner == value)
				{
					return;
				}
				_owner = value;
				PropertySet(this);
			}
		}

		[Ordinal(1)] 
		[RED("attackTDBID")] 
		public TweakDBID AttackTDBID
		{
			get
			{
				if (_attackTDBID == null)
				{
					_attackTDBID = (TweakDBID) CR2WTypeManager.Create("TweakDBID", "attackTDBID", cr2w, this);
				}
				return _attackTDBID;
			}
			set
			{
				if (_attackTDBID == value)
				{
					return;
				}
				_attackTDBID = value;
				PropertySet(this);
			}
		}

		public TriggerContinuousAttackEffector(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
