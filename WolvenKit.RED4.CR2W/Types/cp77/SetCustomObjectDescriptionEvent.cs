using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class SetCustomObjectDescriptionEvent : redEvent
	{
		private CHandle<ObjectScanningDescription> _objectDescription;

		[Ordinal(0)] 
		[RED("objectDescription")] 
		public CHandle<ObjectScanningDescription> ObjectDescription
		{
			get
			{
				if (_objectDescription == null)
				{
					_objectDescription = (CHandle<ObjectScanningDescription>) CR2WTypeManager.Create("handle:ObjectScanningDescription", "objectDescription", cr2w, this);
				}
				return _objectDescription;
			}
			set
			{
				if (_objectDescription == value)
				{
					return;
				}
				_objectDescription = value;
				PropertySet(this);
			}
		}

		public SetCustomObjectDescriptionEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
