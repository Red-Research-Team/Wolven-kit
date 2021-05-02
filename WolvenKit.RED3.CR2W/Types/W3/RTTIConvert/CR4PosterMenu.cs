using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CR4PosterMenu : CR4MenuBase
	{
		[Ordinal(1)] [RED("m_posterEntity")] 		public CHandle<W3Poster> M_posterEntity { get; set;}

		[Ordinal(2)] [RED("m_fxSetDescriptionSFF")] 		public CHandle<CScriptedFlashFunction> M_fxSetDescriptionSFF { get; set;}

		[Ordinal(3)] [RED("m_fxSetSubtitlesHackSFF")] 		public CHandle<CScriptedFlashFunction> M_fxSetSubtitlesHackSFF { get; set;}

		public CR4PosterMenu(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CR4PosterMenu(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}