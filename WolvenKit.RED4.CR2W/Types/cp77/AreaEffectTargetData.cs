using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class AreaEffectTargetData : IScriptable
	{
		private CName _areaEffectID;
		private CBool _onSelf;
		private CBool _onSlaves;

		[Ordinal(0)] 
		[RED("areaEffectID")] 
		public CName AreaEffectID
		{
			get => GetProperty(ref _areaEffectID);
			set => SetProperty(ref _areaEffectID, value);
		}

		[Ordinal(1)] 
		[RED("onSelf")] 
		public CBool OnSelf
		{
			get => GetProperty(ref _onSelf);
			set => SetProperty(ref _onSelf, value);
		}

		[Ordinal(2)] 
		[RED("onSlaves")] 
		public CBool OnSlaves
		{
			get => GetProperty(ref _onSlaves);
			set => SetProperty(ref _onSlaves, value);
		}

		public AreaEffectTargetData(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
