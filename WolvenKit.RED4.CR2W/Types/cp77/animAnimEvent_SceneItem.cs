using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimEvent_SceneItem : animAnimEvent
	{
		private CName _boneName;

		[Ordinal(3)] 
		[RED("boneName")] 
		public CName BoneName
		{
			get
			{
				if (_boneName == null)
				{
					_boneName = (CName) CR2WTypeManager.Create("CName", "boneName", cr2w, this);
				}
				return _boneName;
			}
			set
			{
				if (_boneName == value)
				{
					return;
				}
				_boneName = value;
				PropertySet(this);
			}
		}

		public animAnimEvent_SceneItem(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
