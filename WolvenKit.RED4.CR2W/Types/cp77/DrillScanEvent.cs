using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class DrillScanEvent : redEvent
	{
		private CBool _isScanning;

		[Ordinal(0)] 
		[RED("IsScanning")] 
		public CBool IsScanning
		{
			get
			{
				if (_isScanning == null)
				{
					_isScanning = (CBool) CR2WTypeManager.Create("Bool", "IsScanning", cr2w, this);
				}
				return _isScanning;
			}
			set
			{
				if (_isScanning == value)
				{
					return;
				}
				_isScanning = value;
				PropertySet(this);
			}
		}

		public DrillScanEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
