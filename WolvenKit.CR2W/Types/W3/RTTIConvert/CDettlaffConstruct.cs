using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CDettlaffConstruct : CNewNPC
	{
		[RED("timeBetweenHits")] 		public CFloat TimeBetweenHits { get; set;}

		[RED("timeBetweenFireDamage")] 		public CFloat TimeBetweenFireDamage { get; set;}

		[RED("baseStat")] 		public CEnum<EBaseCharacterStats> BaseStat { get; set;}

		[RED("requiredHits")] 		public CInt32 RequiredHits { get; set;}

		[RED("effectOnTakeDamage")] 		public CName EffectOnTakeDamage { get; set;}

		[RED("timeToDestroy")] 		public CFloat TimeToDestroy { get; set;}

		public CDettlaffConstruct(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CDettlaffConstruct(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}