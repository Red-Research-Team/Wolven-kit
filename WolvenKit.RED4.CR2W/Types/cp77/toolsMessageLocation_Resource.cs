using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class toolsMessageLocation_Resource : toolsIMessageLocation
	{
		private MessageResourcePath _path;

		[Ordinal(0)] 
		[RED("path")] 
		public MessageResourcePath Path
		{
			get
			{
				if (_path == null)
				{
					_path = (MessageResourcePath) CR2WTypeManager.Create("MessageResourcePath", "path", cr2w, this);
				}
				return _path;
			}
			set
			{
				if (_path == value)
				{
					return;
				}
				_path = value;
				PropertySet(this);
			}
		}

		public toolsMessageLocation_Resource(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
