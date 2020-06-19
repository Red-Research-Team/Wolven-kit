using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CExplorationStateTransitionAbstract : CExplorationStateAbstract
	{
		[RED("m_TransitionOriginStateN")] 		public CName M_TransitionOriginStateN { get; set;}

		[RED("m_TransitionEndStateN")] 		public CName M_TransitionEndStateN { get; set;}

		public CExplorationStateTransitionAbstract(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CExplorationStateTransitionAbstract(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}