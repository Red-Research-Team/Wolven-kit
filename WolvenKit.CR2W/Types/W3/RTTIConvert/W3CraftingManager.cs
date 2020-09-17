using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3CraftingManager : CObject
	{
		[Ordinal(1)] [RED("schematics", 2,0)] 		public CArray<SCraftingSchematic> Schematics { get; set;}

		[Ordinal(2)] [RED("craftMasterComp")] 		public CHandle<W3CraftsmanComponent> CraftMasterComp { get; set;}

		public W3CraftingManager(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3CraftingManager(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}