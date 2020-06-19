using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CStorySceneSectionVariant : CVariable
	{
		[RED("id")] 		public CUInt32 Id { get; set;}

		[RED("localeId")] 		public CUInt32 LocaleId { get; set;}

		[RED("events", 2,0)] 		public CArray<CGUID> Events { get; set;}

		[RED("elementInfo", 2,0)] 		public CArray<CStorySceneSectionVariantElementInfo> ElementInfo { get; set;}

		public CStorySceneSectionVariant(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CStorySceneSectionVariant(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}