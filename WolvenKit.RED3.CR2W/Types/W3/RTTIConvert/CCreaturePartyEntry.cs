using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CCreaturePartyEntry : CBaseCreatureEntry
	{
		[Ordinal(1)] [RED("subDefinitions", 2,0)] 		public CArray<CPtr<CSpawnTreeEntrySubDefinition>> SubDefinitions { get; set;}

		[Ordinal(2)] [RED("partySpawnOrganizer")] 		public CHandle<CPartySpawnOrganizer> PartySpawnOrganizer { get; set;}

		[Ordinal(3)] [RED("blockChats")] 		public CBool BlockChats { get; set;}

		[Ordinal(4)] [RED("synchronizeWork")] 		public CBool SynchronizeWork { get; set;}

		public CCreaturePartyEntry(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CCreaturePartyEntry(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}