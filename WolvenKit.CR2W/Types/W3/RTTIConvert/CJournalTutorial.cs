using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CJournalTutorial : CJournalChildBase
	{
		[RED("name")] 		public LocalizedString Name { get; set;}

		[RED("image")] 		public CString Image { get; set;}

		[RED("video")] 		public CString Video { get; set;}

		[RED("description")] 		public LocalizedString Description { get; set;}

		[RED("dlcLock")] 		public CName DlcLock { get; set;}

		[RED("active")] 		public CBool Active { get; set;}

		public CJournalTutorial(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CJournalTutorial(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}