using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3QuestCond_A_closerToTargetThan_B : CQuestScriptedCondition
	{
		[RED("object_A_tag")] 		public CName Object_A_tag { get; set;}

		[RED("object_B_tag")] 		public CName Object_B_tag { get; set;}

		[RED("targetTag")] 		public CName TargetTag { get; set;}

		public W3QuestCond_A_closerToTargetThan_B(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3QuestCond_A_closerToTargetThan_B(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}