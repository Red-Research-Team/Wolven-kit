using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskLeshyRootAttack : CBTTaskAttack
	{
		[Ordinal(1)] [RED("loopTime")] 		public CFloat LoopTime { get; set;}

		[Ordinal(2)] [RED("attackRange")] 		public CFloat AttackRange { get; set;}

		[Ordinal(3)] [RED("dodgeable")] 		public CFloat Dodgeable { get; set;}

		[Ordinal(4)] [RED("projEntity")] 		public CHandle<CEntityTemplate> ProjEntity { get; set;}

		[Ordinal(5)] [RED("collisionGroups", 2,0)] 		public CArray<CName> CollisionGroups { get; set;}

		public CBTTaskLeshyRootAttack(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskLeshyRootAttack(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}