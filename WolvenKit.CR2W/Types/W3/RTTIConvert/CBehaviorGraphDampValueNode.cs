using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehaviorGraphDampValueNode : CBehaviorGraphValueBaseNode
	{
		[RED("increaseSpeed")] 		public CFloat IncreaseSpeed { get; set;}

		[RED("decreaseSpeed")] 		public CFloat DecreaseSpeed { get; set;}

		[RED("absolute")] 		public CBool Absolute { get; set;}

		[RED("startFromDefault")] 		public CBool StartFromDefault { get; set;}

		[RED("defaultValue")] 		public CFloat DefaultValue { get; set;}

		[RED("cachedDefaultValNode")] 		public CPtr<CBehaviorGraphValueNode> CachedDefaultValNode { get; set;}

		[RED("cachedIncSpeedNode")] 		public CPtr<CBehaviorGraphValueNode> CachedIncSpeedNode { get; set;}

		[RED("cachedDecSpeedNode")] 		public CPtr<CBehaviorGraphValueNode> CachedDecSpeedNode { get; set;}

		public CBehaviorGraphDampValueNode(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public override CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehaviorGraphDampValueNode(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}