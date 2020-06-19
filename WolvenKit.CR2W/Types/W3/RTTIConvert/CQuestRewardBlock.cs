using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CQuestRewardBlock : CQuestGraphBlock
	{
		[RED("rewardName")] 		public CName RewardName { get; set;}

		[RED("targetEntityTag")] 		public CName TargetEntityTag { get; set;}

		[RED("caption")] 		public CString Caption { get; set;}

		public CQuestRewardBlock(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CQuestRewardBlock(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}