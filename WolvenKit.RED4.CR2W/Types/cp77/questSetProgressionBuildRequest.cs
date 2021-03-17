using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questSetProgressionBuildRequest : gamePlayerScriptableSystemRequest
	{
		private TweakDBID _buildID;

		[Ordinal(1)] 
		[RED("buildID")] 
		public TweakDBID BuildID
		{
			get => GetProperty(ref _buildID);
			set => SetProperty(ref _buildID, value);
		}

		public questSetProgressionBuildRequest(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
