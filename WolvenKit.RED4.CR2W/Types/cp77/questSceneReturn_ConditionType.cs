using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questSceneReturn_ConditionType : questISceneConditionType
	{
		private raRef<scnSceneResource> _sceneFile;
		private CArray<CHandle<scnIReturnCondition>> _returnConditions;

		[Ordinal(0)] 
		[RED("sceneFile")] 
		public raRef<scnSceneResource> SceneFile
		{
			get => GetProperty(ref _sceneFile);
			set => SetProperty(ref _sceneFile, value);
		}

		[Ordinal(1)] 
		[RED("returnConditions")] 
		public CArray<CHandle<scnIReturnCondition>> ReturnConditions
		{
			get => GetProperty(ref _returnConditions);
			set => SetProperty(ref _returnConditions, value);
		}

		public questSceneReturn_ConditionType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
