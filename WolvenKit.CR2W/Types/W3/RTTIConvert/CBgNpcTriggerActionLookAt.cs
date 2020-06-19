using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBgNpcTriggerActionLookAt : IBgNpcTriggerAction
	{
		[RED("type")] 		public CEnum<EReactionLookAtType> Type { get; set;}

		[RED("onlyPlayer")] 		public CBool OnlyPlayer { get; set;}

		[RED("maxDelay")] 		public CFloat MaxDelay { get; set;}

		public CBgNpcTriggerActionLookAt(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBgNpcTriggerActionLookAt(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}