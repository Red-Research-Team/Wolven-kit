using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class EvaluateMinigame : redEvent
	{
		private CHandle<gameIBlackboard> _minigameBB;
		private TweakDBID _reward;
		private CString _journalEntry;
		private CName _fact;
		private CInt32 _factValue;
		private gameItemID _item;
		private CBool _showPopup;
		private CBool _returnToJournal;

		[Ordinal(0)] 
		[RED("minigameBB")] 
		public CHandle<gameIBlackboard> MinigameBB
		{
			get
			{
				if (_minigameBB == null)
				{
					_minigameBB = (CHandle<gameIBlackboard>) CR2WTypeManager.Create("handle:gameIBlackboard", "minigameBB", cr2w, this);
				}
				return _minigameBB;
			}
			set
			{
				if (_minigameBB == value)
				{
					return;
				}
				_minigameBB = value;
				PropertySet(this);
			}
		}

		[Ordinal(1)] 
		[RED("reward")] 
		public TweakDBID Reward
		{
			get
			{
				if (_reward == null)
				{
					_reward = (TweakDBID) CR2WTypeManager.Create("TweakDBID", "reward", cr2w, this);
				}
				return _reward;
			}
			set
			{
				if (_reward == value)
				{
					return;
				}
				_reward = value;
				PropertySet(this);
			}
		}

		[Ordinal(2)] 
		[RED("journalEntry")] 
		public CString JournalEntry
		{
			get
			{
				if (_journalEntry == null)
				{
					_journalEntry = (CString) CR2WTypeManager.Create("String", "journalEntry", cr2w, this);
				}
				return _journalEntry;
			}
			set
			{
				if (_journalEntry == value)
				{
					return;
				}
				_journalEntry = value;
				PropertySet(this);
			}
		}

		[Ordinal(3)] 
		[RED("fact")] 
		public CName Fact
		{
			get
			{
				if (_fact == null)
				{
					_fact = (CName) CR2WTypeManager.Create("CName", "fact", cr2w, this);
				}
				return _fact;
			}
			set
			{
				if (_fact == value)
				{
					return;
				}
				_fact = value;
				PropertySet(this);
			}
		}

		[Ordinal(4)] 
		[RED("factValue")] 
		public CInt32 FactValue
		{
			get
			{
				if (_factValue == null)
				{
					_factValue = (CInt32) CR2WTypeManager.Create("Int32", "factValue", cr2w, this);
				}
				return _factValue;
			}
			set
			{
				if (_factValue == value)
				{
					return;
				}
				_factValue = value;
				PropertySet(this);
			}
		}

		[Ordinal(5)] 
		[RED("item")] 
		public gameItemID Item
		{
			get
			{
				if (_item == null)
				{
					_item = (gameItemID) CR2WTypeManager.Create("gameItemID", "item", cr2w, this);
				}
				return _item;
			}
			set
			{
				if (_item == value)
				{
					return;
				}
				_item = value;
				PropertySet(this);
			}
		}

		[Ordinal(6)] 
		[RED("showPopup")] 
		public CBool ShowPopup
		{
			get
			{
				if (_showPopup == null)
				{
					_showPopup = (CBool) CR2WTypeManager.Create("Bool", "showPopup", cr2w, this);
				}
				return _showPopup;
			}
			set
			{
				if (_showPopup == value)
				{
					return;
				}
				_showPopup = value;
				PropertySet(this);
			}
		}

		[Ordinal(7)] 
		[RED("returnToJournal")] 
		public CBool ReturnToJournal
		{
			get
			{
				if (_returnToJournal == null)
				{
					_returnToJournal = (CBool) CR2WTypeManager.Create("Bool", "returnToJournal", cr2w, this);
				}
				return _returnToJournal;
			}
			set
			{
				if (_returnToJournal == value)
				{
					return;
				}
				_returnToJournal = value;
				PropertySet(this);
			}
		}

		public EvaluateMinigame(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
