using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SUISavedData : CVariable
	{
		[Ordinal(1)] [RED("panelName")] 		public CName PanelName { get; set;}

		[Ordinal(2)] [RED("selectedTag")] 		public CName SelectedTag { get; set;}

		[Ordinal(3)] [RED("openedCategories", 2,0)] 		public CArray<CName> OpenedCategories { get; set;}

		[Ordinal(4)] [RED("gridItem")] 		public SItemUniqueId GridItem { get; set;}

		[Ordinal(5)] [RED("slotID")] 		public CInt32 SlotID { get; set;}

		[Ordinal(6)] [RED("selectedModule")] 		public CInt32 SelectedModule { get; set;}

		public SUISavedData(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SUISavedData(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}