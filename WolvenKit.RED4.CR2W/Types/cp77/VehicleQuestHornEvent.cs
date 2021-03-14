using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class VehicleQuestHornEvent : redEvent
	{
		private CFloat _honkTime;

		[Ordinal(0)] 
		[RED("honkTime")] 
		public CFloat HonkTime
		{
			get
			{
				if (_honkTime == null)
				{
					_honkTime = (CFloat) CR2WTypeManager.Create("Float", "honkTime", cr2w, this);
				}
				return _honkTime;
			}
			set
			{
				if (_honkTime == value)
				{
					return;
				}
				_honkTime = value;
				PropertySet(this);
			}
		}

		public VehicleQuestHornEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
