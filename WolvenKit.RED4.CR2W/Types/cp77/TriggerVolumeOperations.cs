using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class TriggerVolumeOperations : DeviceOperations
	{
		private CArray<STriggerVolumeOperationData> _triggerVolumeOperations;

		[Ordinal(2)] 
		[RED("triggerVolumeOperations")] 
		public CArray<STriggerVolumeOperationData> TriggerVolumeOperations_
		{
			get
			{
				if (_triggerVolumeOperations == null)
				{
					_triggerVolumeOperations = (CArray<STriggerVolumeOperationData>) CR2WTypeManager.Create("array:STriggerVolumeOperationData", "triggerVolumeOperations", cr2w, this);
				}
				return _triggerVolumeOperations;
			}
			set
			{
				if (_triggerVolumeOperations == value)
				{
					return;
				}
				_triggerVolumeOperations = value;
				PropertySet(this);
			}
		}

		public TriggerVolumeOperations(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
