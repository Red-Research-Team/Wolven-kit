using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskChangeStanceDef : IBehTreeTaskDefinition
	{
		[Ordinal(1)] [RED("newStance")] 		public CEnum<ENpcStance> NewStance { get; set;}

		[Ordinal(2)] [RED("setPrevStanceOnDeactivation")] 		public CBool SetPrevStanceOnDeactivation { get; set;}

		[Ordinal(3)] [RED("onDeactivate")] 		public CBool OnDeactivate { get; set;}

		[Ordinal(4)] [RED("changeToFlyOnlyIfAboveGround")] 		public CBool ChangeToFlyOnlyIfAboveGround { get; set;}

		public CBTTaskChangeStanceDef(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskChangeStanceDef(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}