using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questSetLocationName_NodeType : questIUIManagerNodeType
	{
		private CString _locationName;
		private CEnum<questLocationAction> _action;
		private TweakDBID _districtID;
		private CBool _isNewLocation;

		[Ordinal(0)] 
		[RED("locationName")] 
		public CString LocationName
		{
			get => GetProperty(ref _locationName);
			set => SetProperty(ref _locationName, value);
		}

		[Ordinal(1)] 
		[RED("action")] 
		public CEnum<questLocationAction> Action
		{
			get => GetProperty(ref _action);
			set => SetProperty(ref _action, value);
		}

		[Ordinal(2)] 
		[RED("districtID")] 
		public TweakDBID DistrictID
		{
			get => GetProperty(ref _districtID);
			set => SetProperty(ref _districtID, value);
		}

		[Ordinal(3)] 
		[RED("isNewLocation")] 
		public CBool IsNewLocation
		{
			get => GetProperty(ref _isNewLocation);
			set => SetProperty(ref _isNewLocation, value);
		}

		public questSetLocationName_NodeType(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
