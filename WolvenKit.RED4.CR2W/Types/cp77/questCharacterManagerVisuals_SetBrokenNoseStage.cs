using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questCharacterManagerVisuals_SetBrokenNoseStage : questICharacterManagerVisuals_NodeSubType
	{
		private CEnum<gameuiCharacterCustomization_BrokenNoseStage> _brokenNoseStage;

		[Ordinal(0)] 
		[RED("brokenNoseStage")] 
		public CEnum<gameuiCharacterCustomization_BrokenNoseStage> BrokenNoseStage
		{
			get
			{
				if (_brokenNoseStage == null)
				{
					_brokenNoseStage = (CEnum<gameuiCharacterCustomization_BrokenNoseStage>) CR2WTypeManager.Create("gameuiCharacterCustomization_BrokenNoseStage", "brokenNoseStage", cr2w, this);
				}
				return _brokenNoseStage;
			}
			set
			{
				if (_brokenNoseStage == value)
				{
					return;
				}
				_brokenNoseStage = value;
				PropertySet(this);
			}
		}

		public questCharacterManagerVisuals_SetBrokenNoseStage(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
