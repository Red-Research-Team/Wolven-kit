using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3TutorialManagerUIHandlerStateBooksCommonMenu : W3TutorialManagerUIHandlerStateTutHandlerBaseState
	{
		[RED("OPEN_COMMON_MENU")] 		public CName OPEN_COMMON_MENU { get; set;}

		[RED("SELECT_GLOSSARY")] 		public CName SELECT_GLOSSARY { get; set;}

		public W3TutorialManagerUIHandlerStateBooksCommonMenu(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3TutorialManagerUIHandlerStateBooksCommonMenu(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}