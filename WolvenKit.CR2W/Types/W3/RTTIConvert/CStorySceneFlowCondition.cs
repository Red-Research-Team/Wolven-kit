using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CStorySceneFlowCondition : CStorySceneControlPart
	{
		[RED("trueLink")] 		public CPtr<CStorySceneLinkElement> TrueLink { get; set;}

		[RED("falseLink")] 		public CPtr<CStorySceneLinkElement> FalseLink { get; set;}

		[RED("questCondition")] 		public CPtr<IQuestCondition> QuestCondition { get; set;}

		public CStorySceneFlowCondition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CStorySceneFlowCondition(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}