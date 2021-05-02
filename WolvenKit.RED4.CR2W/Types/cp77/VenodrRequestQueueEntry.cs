using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class VenodrRequestQueueEntry : IScriptable
	{
		private CInt32 _requestID;
		private gameItemID _itemID;

		[Ordinal(0)] 
		[RED("requestID")] 
		public CInt32 RequestID
		{
			get => GetProperty(ref _requestID);
			set => SetProperty(ref _requestID, value);
		}

		[Ordinal(1)] 
		[RED("itemID")] 
		public gameItemID ItemID
		{
			get => GetProperty(ref _itemID);
			set => SetProperty(ref _itemID, value);
		}

		public VenodrRequestQueueEntry(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
