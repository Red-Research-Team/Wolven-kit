using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class scnEndNode : scnSceneGraphNode
	{
		private CEnum<scnEndNodeNsType> _type;

		[Ordinal(3)] 
		[RED("type")] 
		public CEnum<scnEndNodeNsType> Type
		{
			get => GetProperty(ref _type);
			set => SetProperty(ref _type, value);
		}

		public scnEndNode(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
