using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameuiScreenProjectionsData : IScriptable
	{
		private CArray<CHandle<inkScreenProjection>> _data;

		[Ordinal(0)] 
		[RED("data")] 
		public CArray<CHandle<inkScreenProjection>> Data
		{
			get => GetProperty(ref _data);
			set => SetProperty(ref _data, value);
		}

		public gameuiScreenProjectionsData(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
