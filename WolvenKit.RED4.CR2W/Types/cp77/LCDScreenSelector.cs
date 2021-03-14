using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class LCDScreenSelector : inkTweakDBIDSelector
	{
		private TweakDBID _customMessageID;
		private CBool _replaceTextWithCustomNumber;
		private CInt32 _customNumber;

		[Ordinal(1)] 
		[RED("customMessageID")] 
		public TweakDBID CustomMessageID
		{
			get
			{
				if (_customMessageID == null)
				{
					_customMessageID = (TweakDBID) CR2WTypeManager.Create("TweakDBID", "customMessageID", cr2w, this);
				}
				return _customMessageID;
			}
			set
			{
				if (_customMessageID == value)
				{
					return;
				}
				_customMessageID = value;
				PropertySet(this);
			}
		}

		[Ordinal(2)] 
		[RED("replaceTextWithCustomNumber")] 
		public CBool ReplaceTextWithCustomNumber
		{
			get
			{
				if (_replaceTextWithCustomNumber == null)
				{
					_replaceTextWithCustomNumber = (CBool) CR2WTypeManager.Create("Bool", "replaceTextWithCustomNumber", cr2w, this);
				}
				return _replaceTextWithCustomNumber;
			}
			set
			{
				if (_replaceTextWithCustomNumber == value)
				{
					return;
				}
				_replaceTextWithCustomNumber = value;
				PropertySet(this);
			}
		}

		[Ordinal(3)] 
		[RED("customNumber")] 
		public CInt32 CustomNumber
		{
			get
			{
				if (_customNumber == null)
				{
					_customNumber = (CInt32) CR2WTypeManager.Create("Int32", "customNumber", cr2w, this);
				}
				return _customNumber;
			}
			set
			{
				if (_customNumber == value)
				{
					return;
				}
				_customNumber = value;
				PropertySet(this);
			}
		}

		public LCDScreenSelector(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
