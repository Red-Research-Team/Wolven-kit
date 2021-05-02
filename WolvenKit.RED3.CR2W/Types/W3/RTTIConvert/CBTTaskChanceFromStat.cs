using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskChanceFromStat : IBehTreeTask
	{
		[Ordinal(1)] [RED("ifNot")] 		public CBool IfNot { get; set;}

		[Ordinal(2)] [RED("statName")] 		public CName StatName { get; set;}

		[Ordinal(3)] [RED("frequency")] 		public CFloat Frequency { get; set;}

		[Ordinal(4)] [RED("scaleWithNumberOfOpponents")] 		public CBool ScaleWithNumberOfOpponents { get; set;}

		[Ordinal(5)] [RED("chancePerOpponent")] 		public CInt32 ChancePerOpponent { get; set;}

		[Ordinal(6)] [RED("lastRollTime")] 		public CFloat LastRollTime { get; set;}

		public CBTTaskChanceFromStat(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskChanceFromStat(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}