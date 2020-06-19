using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CParticleInitializerSpawnCircle : IParticleInitializer
	{
		[RED("innerRadius")] 		public CPtr<IEvaluatorFloat> InnerRadius { get; set;}

		[RED("outerRadius")] 		public CPtr<IEvaluatorFloat> OuterRadius { get; set;}

		[RED("surfaceOnly")] 		public CBool SurfaceOnly { get; set;}

		[RED("worldSpace")] 		public CBool WorldSpace { get; set;}

		[RED("spawnToLocal")] 		public CMatrix SpawnToLocal { get; set;}

		public CParticleInitializerSpawnCircle(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CParticleInitializerSpawnCircle(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}