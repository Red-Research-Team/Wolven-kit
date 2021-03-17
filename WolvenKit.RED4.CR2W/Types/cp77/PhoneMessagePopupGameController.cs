using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class PhoneMessagePopupGameController : gameuiWidgetGameController
	{
		private inkWidgetReference _content;
		private inkTextWidgetReference _title;
		private inkImageWidgetReference _avatarImage;
		private inkWidgetReference _menuBackgrouns;
		private inkWidgetReference _hintTrack;
		private inkWidgetReference _hintClose;
		private inkWidgetReference _hintReply;
		private inkWidgetReference _hintMessenger;
		private wCHandle<gameIBlackboard> _blackboard;
		private CHandle<UI_ComDeviceDef> _blackboardDef;
		private CHandle<gameuiGameSystemUI> _uiSystem;
		private wCHandle<gameObject> _player;
		private wCHandle<gameJournalManager> _journalMgr;
		private CHandle<JournalNotificationData> _data;
		private wCHandle<gameJournalPhoneMessage> _entry;
		private wCHandle<gameJournalContact> _contactEntry;
		private wCHandle<gameJournalEntry> _attachment;
		private CUInt32 _attachmentHash;
		private wCHandle<gameJournalEntry> _activeEntry;
		private wCHandle<MessengerDialogViewController> _dialogViewController;
		private CHandle<inkanimProxy> _proxy;

		[Ordinal(2)] 
		[RED("content")] 
		public inkWidgetReference Content
		{
			get => GetProperty(ref _content);
			set => SetProperty(ref _content, value);
		}

		[Ordinal(3)] 
		[RED("title")] 
		public inkTextWidgetReference Title
		{
			get => GetProperty(ref _title);
			set => SetProperty(ref _title, value);
		}

		[Ordinal(4)] 
		[RED("avatarImage")] 
		public inkImageWidgetReference AvatarImage
		{
			get => GetProperty(ref _avatarImage);
			set => SetProperty(ref _avatarImage, value);
		}

		[Ordinal(5)] 
		[RED("menuBackgrouns")] 
		public inkWidgetReference MenuBackgrouns
		{
			get => GetProperty(ref _menuBackgrouns);
			set => SetProperty(ref _menuBackgrouns, value);
		}

		[Ordinal(6)] 
		[RED("hintTrack")] 
		public inkWidgetReference HintTrack
		{
			get => GetProperty(ref _hintTrack);
			set => SetProperty(ref _hintTrack, value);
		}

		[Ordinal(7)] 
		[RED("hintClose")] 
		public inkWidgetReference HintClose
		{
			get => GetProperty(ref _hintClose);
			set => SetProperty(ref _hintClose, value);
		}

		[Ordinal(8)] 
		[RED("hintReply")] 
		public inkWidgetReference HintReply
		{
			get => GetProperty(ref _hintReply);
			set => SetProperty(ref _hintReply, value);
		}

		[Ordinal(9)] 
		[RED("hintMessenger")] 
		public inkWidgetReference HintMessenger
		{
			get => GetProperty(ref _hintMessenger);
			set => SetProperty(ref _hintMessenger, value);
		}

		[Ordinal(10)] 
		[RED("blackboard")] 
		public wCHandle<gameIBlackboard> Blackboard
		{
			get => GetProperty(ref _blackboard);
			set => SetProperty(ref _blackboard, value);
		}

		[Ordinal(11)] 
		[RED("blackboardDef")] 
		public CHandle<UI_ComDeviceDef> BlackboardDef
		{
			get => GetProperty(ref _blackboardDef);
			set => SetProperty(ref _blackboardDef, value);
		}

		[Ordinal(12)] 
		[RED("uiSystem")] 
		public CHandle<gameuiGameSystemUI> UiSystem
		{
			get => GetProperty(ref _uiSystem);
			set => SetProperty(ref _uiSystem, value);
		}

		[Ordinal(13)] 
		[RED("player")] 
		public wCHandle<gameObject> Player
		{
			get => GetProperty(ref _player);
			set => SetProperty(ref _player, value);
		}

		[Ordinal(14)] 
		[RED("journalMgr")] 
		public wCHandle<gameJournalManager> JournalMgr
		{
			get => GetProperty(ref _journalMgr);
			set => SetProperty(ref _journalMgr, value);
		}

		[Ordinal(15)] 
		[RED("data")] 
		public CHandle<JournalNotificationData> Data
		{
			get => GetProperty(ref _data);
			set => SetProperty(ref _data, value);
		}

		[Ordinal(16)] 
		[RED("entry")] 
		public wCHandle<gameJournalPhoneMessage> Entry
		{
			get => GetProperty(ref _entry);
			set => SetProperty(ref _entry, value);
		}

		[Ordinal(17)] 
		[RED("contactEntry")] 
		public wCHandle<gameJournalContact> ContactEntry
		{
			get => GetProperty(ref _contactEntry);
			set => SetProperty(ref _contactEntry, value);
		}

		[Ordinal(18)] 
		[RED("attachment")] 
		public wCHandle<gameJournalEntry> Attachment
		{
			get => GetProperty(ref _attachment);
			set => SetProperty(ref _attachment, value);
		}

		[Ordinal(19)] 
		[RED("attachmentHash")] 
		public CUInt32 AttachmentHash
		{
			get => GetProperty(ref _attachmentHash);
			set => SetProperty(ref _attachmentHash, value);
		}

		[Ordinal(20)] 
		[RED("activeEntry")] 
		public wCHandle<gameJournalEntry> ActiveEntry
		{
			get => GetProperty(ref _activeEntry);
			set => SetProperty(ref _activeEntry, value);
		}

		[Ordinal(21)] 
		[RED("dialogViewController")] 
		public wCHandle<MessengerDialogViewController> DialogViewController
		{
			get => GetProperty(ref _dialogViewController);
			set => SetProperty(ref _dialogViewController, value);
		}

		[Ordinal(22)] 
		[RED("proxy")] 
		public CHandle<inkanimProxy> Proxy
		{
			get => GetProperty(ref _proxy);
			set => SetProperty(ref _proxy, value);
		}

		public PhoneMessagePopupGameController(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
