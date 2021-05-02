using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class entReplicatedAnimFeature : entReplicatedItem
	{
		private CName _name;
		private CHandle<animAnimFeature> _value;
		private CBool _invokeCallback;

		[Ordinal(2)] 
		[RED("name")] 
		public CName Name
		{
			get => GetProperty(ref _name);
			set => SetProperty(ref _name, value);
		}

		[Ordinal(3)] 
		[RED("value")] 
		public CHandle<animAnimFeature> Value
		{
			get => GetProperty(ref _value);
			set => SetProperty(ref _value, value);
		}

		[Ordinal(4)] 
		[RED("invokeCallback")] 
		public CBool InvokeCallback
		{
			get => GetProperty(ref _invokeCallback);
			set => SetProperty(ref _invokeCallback, value);
		}

		public entReplicatedAnimFeature(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
