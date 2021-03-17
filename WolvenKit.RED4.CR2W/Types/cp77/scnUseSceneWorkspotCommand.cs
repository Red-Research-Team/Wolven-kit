using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class scnUseSceneWorkspotCommand : AIBaseUseWorkspotCommand
	{
		private scnSceneInstanceId _sceneInstanceId;
		private scnSceneWorkspotInstanceId _workspotInstanceId;
		private workWorkspotItemOverride _itemOverride;
		private scnNodeId _nodeId;

		[Ordinal(11)] 
		[RED("sceneInstanceId")] 
		public scnSceneInstanceId SceneInstanceId
		{
			get => GetProperty(ref _sceneInstanceId);
			set => SetProperty(ref _sceneInstanceId, value);
		}

		[Ordinal(12)] 
		[RED("workspotInstanceId")] 
		public scnSceneWorkspotInstanceId WorkspotInstanceId
		{
			get => GetProperty(ref _workspotInstanceId);
			set => SetProperty(ref _workspotInstanceId, value);
		}

		[Ordinal(13)] 
		[RED("itemOverride")] 
		public workWorkspotItemOverride ItemOverride
		{
			get => GetProperty(ref _itemOverride);
			set => SetProperty(ref _itemOverride, value);
		}

		[Ordinal(14)] 
		[RED("nodeId")] 
		public scnNodeId NodeId
		{
			get => GetProperty(ref _nodeId);
			set => SetProperty(ref _nodeId, value);
		}

		public scnUseSceneWorkspotCommand(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
