using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public partial class CGenericGrassMask : CResource
	{
		[Ordinal(1)] [RED("maskRes")] 		public CUInt32 MaskRes { get; set;}

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CGenericGrassMask(cr2w, parent, name);

	}
}