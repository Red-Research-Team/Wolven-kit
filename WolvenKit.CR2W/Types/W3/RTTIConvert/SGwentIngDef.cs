using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SGwentIngDef : CVariable
	{
		[RED("itemName")] 		public CName ItemName { get; set;}

		[RED("reqLevel")] 		public CInt32 ReqLevel { get; set;}

		[RED("quantityMin")] 		public CInt32 QuantityMin { get; set;}

		[RED("quantityMax")] 		public CInt32 QuantityMax { get; set;}

		public SGwentIngDef(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SGwentIngDef(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}