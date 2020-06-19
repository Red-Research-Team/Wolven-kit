using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehaviorGraphGameplayAdditiveNode : CBehaviorGraphNode
	{
		[RED("level_0")] 		public SGameplayAdditiveLevel Level_0 { get; set;}

		[RED("level_1")] 		public SGameplayAdditiveLevel Level_1 { get; set;}

		[RED("gatherEvents")] 		public CBool GatherEvents { get; set;}

		[RED("cachedInputNode")] 		public CPtr<CBehaviorGraphNode> CachedInputNode { get; set;}

		public CBehaviorGraphGameplayAdditiveNode(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehaviorGraphGameplayAdditiveNode(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}