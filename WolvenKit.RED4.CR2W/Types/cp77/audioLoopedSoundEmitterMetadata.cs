using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class audioLoopedSoundEmitterMetadata : audioEmitterMetadata
	{
		private CName _loopSound;

		[Ordinal(1)] 
		[RED("loopSound")] 
		public CName LoopSound
		{
			get
			{
				if (_loopSound == null)
				{
					_loopSound = (CName) CR2WTypeManager.Create("CName", "loopSound", cr2w, this);
				}
				return _loopSound;
			}
			set
			{
				if (_loopSound == value)
				{
					return;
				}
				_loopSound = value;
				PropertySet(this);
			}
		}

		public audioLoopedSoundEmitterMetadata(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
