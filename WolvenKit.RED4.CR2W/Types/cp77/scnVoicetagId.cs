using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class scnVoicetagId : CVariable
	{
		private CRUID _id;

		[Ordinal(0)] 
		[RED("id")] 
		public CRUID Id
		{
			get
			{
				if (_id == null)
				{
					_id = (CRUID) CR2WTypeManager.Create("CRUID", "id", cr2w, this);
				}
				return _id;
			}
			set
			{
				if (_id == value)
				{
					return;
				}
				_id = value;
				PropertySet(this);
			}
		}

		public scnVoicetagId(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
