using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskMiscreantCrying : IBehTreeTask
	{
		[RED("miscreantName")] 		public CName MiscreantName { get; set;}

		[RED("miscreant")] 		public CHandle<CActor> Miscreant { get; set;}

		[RED("isAvailable")] 		public CBool IsAvailable { get; set;}

		[RED("cryStartEventName")] 		public CName CryStartEventName { get; set;}

		[RED("cryStopEventName")] 		public CName CryStopEventName { get; set;}

		public CBTTaskMiscreantCrying(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskMiscreantCrying(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}