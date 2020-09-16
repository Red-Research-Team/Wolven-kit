using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CQuestEncounterPhaseBlock : CQuestGraphBlock
	{
		[Ordinal(1)] [RED("encounterTag")] 		public CName EncounterTag { get; set;}

		[Ordinal(2)] [RED("encounterSpawnPhase")] 		public CName EncounterSpawnPhase { get; set;}

		public CQuestEncounterPhaseBlock(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CQuestEncounterPhaseBlock(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}