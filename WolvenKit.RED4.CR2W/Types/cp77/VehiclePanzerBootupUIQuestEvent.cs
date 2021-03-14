using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class VehiclePanzerBootupUIQuestEvent : redEvent
	{
		private CEnum<panzerBootupUI> _mode;

		[Ordinal(0)] 
		[RED("mode")] 
		public CEnum<panzerBootupUI> Mode
		{
			get
			{
				if (_mode == null)
				{
					_mode = (CEnum<panzerBootupUI>) CR2WTypeManager.Create("panzerBootupUI", "mode", cr2w, this);
				}
				return _mode;
			}
			set
			{
				if (_mode == value)
				{
					return;
				}
				_mode = value;
				PropertySet(this);
			}
		}

		public VehiclePanzerBootupUIQuestEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
