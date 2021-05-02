using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gamePlayerClimbInfo : IScriptable
	{
		private CHandle<worldgeometryDescriptionResult> _descResult;
		private Vector4 _obstacleEnd;
		private CBool _climbValid;
		private CBool _vaultValid;

		[Ordinal(0)] 
		[RED("descResult")] 
		public CHandle<worldgeometryDescriptionResult> DescResult
		{
			get => GetProperty(ref _descResult);
			set => SetProperty(ref _descResult, value);
		}

		[Ordinal(1)] 
		[RED("obstacleEnd")] 
		public Vector4 ObstacleEnd
		{
			get => GetProperty(ref _obstacleEnd);
			set => SetProperty(ref _obstacleEnd, value);
		}

		[Ordinal(2)] 
		[RED("climbValid")] 
		public CBool ClimbValid
		{
			get => GetProperty(ref _climbValid);
			set => SetProperty(ref _climbValid, value);
		}

		[Ordinal(3)] 
		[RED("vaultValid")] 
		public CBool VaultValid
		{
			get => GetProperty(ref _vaultValid);
			set => SetProperty(ref _vaultValid, value);
		}

		public gamePlayerClimbInfo(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
