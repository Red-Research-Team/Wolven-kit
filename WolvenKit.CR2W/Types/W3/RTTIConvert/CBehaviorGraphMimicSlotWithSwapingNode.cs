using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehaviorGraphMimicSlotWithSwapingNode : CBehaviorGraphMimicSlotNode
	{
		[Ordinal(1)] [RED("from")] 		public CUInt32 From { get; set;}

		[Ordinal(2)] [RED("to")] 		public CUInt32 To { get; set;}

		public CBehaviorGraphMimicSlotWithSwapingNode(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehaviorGraphMimicSlotWithSwapingNode(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}