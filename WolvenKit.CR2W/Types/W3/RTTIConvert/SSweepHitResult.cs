using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SSweepHitResult : CVariable
	{
		[RED("position")] 		public Vector Position { get; set;}

		[RED("normal")] 		public Vector Normal { get; set;}

		[RED("distance")] 		public CFloat Distance { get; set;}

		[RED("component")] 		public CHandle<CComponent> Component { get; set;}

		public SSweepHitResult(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SSweepHitResult(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}