using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class DebuggerProperties : CVariable
	{
		private CBool _exclusiveMode;
		private CName _factActivated;
		private CName _debugName;
		private CArray<CUInt32> _layerIDs;

		[Ordinal(0)] 
		[RED("exclusiveMode")] 
		public CBool ExclusiveMode
		{
			get => GetProperty(ref _exclusiveMode);
			set => SetProperty(ref _exclusiveMode, value);
		}

		[Ordinal(1)] 
		[RED("factActivated")] 
		public CName FactActivated
		{
			get => GetProperty(ref _factActivated);
			set => SetProperty(ref _factActivated, value);
		}

		[Ordinal(2)] 
		[RED("debugName")] 
		public CName DebugName
		{
			get => GetProperty(ref _debugName);
			set => SetProperty(ref _debugName, value);
		}

		[Ordinal(3)] 
		[RED("layerIDs")] 
		public CArray<CUInt32> LayerIDs
		{
			get => GetProperty(ref _layerIDs);
			set => SetProperty(ref _layerIDs, value);
		}

		public DebuggerProperties(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
