using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class BumpNetrunnerMinigameLevel : gamePlayerScriptableSystemRequest
	{
		private CInt32 _completedMinigameLevel;

		[Ordinal(1)] 
		[RED("completedMinigameLevel")] 
		public CInt32 CompletedMinigameLevel
		{
			get
			{
				if (_completedMinigameLevel == null)
				{
					_completedMinigameLevel = (CInt32) CR2WTypeManager.Create("Int32", "completedMinigameLevel", cr2w, this);
				}
				return _completedMinigameLevel;
			}
			set
			{
				if (_completedMinigameLevel == value)
				{
					return;
				}
				_completedMinigameLevel = value;
				PropertySet(this);
			}
		}

		public BumpNetrunnerMinigameLevel(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
