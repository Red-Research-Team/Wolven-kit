using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class CompletionOfFirstEquipRequest : gameScriptableSystemRequest
	{
		private TweakDBID _weaponID;

		[Ordinal(0)] 
		[RED("weaponID")] 
		public TweakDBID WeaponID
		{
			get
			{
				if (_weaponID == null)
				{
					_weaponID = (TweakDBID) CR2WTypeManager.Create("TweakDBID", "weaponID", cr2w, this);
				}
				return _weaponID;
			}
			set
			{
				if (_weaponID == value)
				{
					return;
				}
				_weaponID = value;
				PropertySet(this);
			}
		}

		public CompletionOfFirstEquipRequest(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
