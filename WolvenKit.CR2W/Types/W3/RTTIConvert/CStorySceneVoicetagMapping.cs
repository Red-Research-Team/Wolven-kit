using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CStorySceneVoicetagMapping : CVariable
	{
		[RED("voicetag")] 		public CName Voicetag { get; set;}

		[RED("mustUseContextActor")] 		public CBool MustUseContextActor { get; set;}

		[RED("invulnerable")] 		public CBool Invulnerable { get; set;}

		[RED("actorOptional")] 		public CBool ActorOptional { get; set;}

		public CStorySceneVoicetagMapping(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CStorySceneVoicetagMapping(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}