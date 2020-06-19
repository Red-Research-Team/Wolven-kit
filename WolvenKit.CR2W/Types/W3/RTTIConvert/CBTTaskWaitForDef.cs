using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskWaitForDef : IBehTreeTaskDefinition
	{
		[RED("waitForTag")] 		public CBehTreeValCName WaitForTag { get; set;}

		[RED("timeout")] 		public CBehTreeValFloat Timeout { get; set;}

		[RED("testDistance")] 		public CBehTreeValFloat TestDistance { get; set;}

		public CBTTaskWaitForDef(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskWaitForDef(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}