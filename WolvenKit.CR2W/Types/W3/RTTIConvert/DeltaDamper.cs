using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class DeltaDamper : CObject
	{
		[RED("destValue")] 		public CFloat DestValue { get; set;}

		[RED("currValue")] 		public CFloat CurrValue { get; set;}

		[RED("dampFactor")] 		public CFloat DampFactor { get; set;}

		public DeltaDamper(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new DeltaDamper(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}