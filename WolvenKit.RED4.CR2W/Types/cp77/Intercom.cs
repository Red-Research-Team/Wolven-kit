using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class Intercom : InteractiveDevice
	{
		private CBool _isShortGlitchActive;
		private gameDelayID _shortGlitchDelayID;
		private CName _distractionSound;

		[Ordinal(93)] 
		[RED("isShortGlitchActive")] 
		public CBool IsShortGlitchActive
		{
			get
			{
				if (_isShortGlitchActive == null)
				{
					_isShortGlitchActive = (CBool) CR2WTypeManager.Create("Bool", "isShortGlitchActive", cr2w, this);
				}
				return _isShortGlitchActive;
			}
			set
			{
				if (_isShortGlitchActive == value)
				{
					return;
				}
				_isShortGlitchActive = value;
				PropertySet(this);
			}
		}

		[Ordinal(94)] 
		[RED("shortGlitchDelayID")] 
		public gameDelayID ShortGlitchDelayID
		{
			get
			{
				if (_shortGlitchDelayID == null)
				{
					_shortGlitchDelayID = (gameDelayID) CR2WTypeManager.Create("gameDelayID", "shortGlitchDelayID", cr2w, this);
				}
				return _shortGlitchDelayID;
			}
			set
			{
				if (_shortGlitchDelayID == value)
				{
					return;
				}
				_shortGlitchDelayID = value;
				PropertySet(this);
			}
		}

		[Ordinal(95)] 
		[RED("distractionSound")] 
		public CName DistractionSound
		{
			get
			{
				if (_distractionSound == null)
				{
					_distractionSound = (CName) CR2WTypeManager.Create("CName", "distractionSound", cr2w, this);
				}
				return _distractionSound;
			}
			set
			{
				if (_distractionSound == value)
				{
					return;
				}
				_distractionSound = value;
				PropertySet(this);
			}
		}

		public Intercom(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
