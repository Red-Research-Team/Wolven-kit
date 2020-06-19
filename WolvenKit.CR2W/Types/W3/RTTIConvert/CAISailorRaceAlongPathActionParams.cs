using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CAISailorRaceAlongPathActionParams : ISailorActionParameters
	{
		[RED("boatTag")] 		public CName BoatTag { get; set;}

		[RED("pathTag")] 		public CName PathTag { get; set;}

		[RED("upThePath")] 		public CBool UpThePath { get; set;}

		[RED("startFromBeginning")] 		public CBool StartFromBeginning { get; set;}

		public CAISailorRaceAlongPathActionParams(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CAISailorRaceAlongPathActionParams(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}