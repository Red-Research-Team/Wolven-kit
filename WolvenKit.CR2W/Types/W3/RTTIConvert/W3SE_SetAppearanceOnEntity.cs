using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3SE_SetAppearanceOnEntity : W3SwitchEvent
	{
		[RED("entityHandle")] 		public EntityHandle EntityHandle { get; set;}

		[RED("appearanceName")] 		public CString AppearanceName { get; set;}

		[RED("entity")] 		public CHandle<CEntity> Entity { get; set;}

		public W3SE_SetAppearanceOnEntity(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3SE_SetAppearanceOnEntity(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}