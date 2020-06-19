using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3FocusAreaTrigger : CGameplayEntity
	{
		[RED("intensity")] 		public CFloat Intensity { get; set;}

		[RED("linkedClues", 2,0)] 		public CArray<EntityHandle> LinkedClues { get; set;}

		[RED("linkedCluesTags", 2,0)] 		public CArray<CName> LinkedCluesTags { get; set;}

		public W3FocusAreaTrigger(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3FocusAreaTrigger(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}