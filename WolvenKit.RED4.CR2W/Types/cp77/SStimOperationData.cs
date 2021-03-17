using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class SStimOperationData : CVariable
	{
		private CEnum<DeviceStimType> _stimType;
		private CFloat _lifeTime;
		private CFloat _radius;
		private CEnum<EEffectOperationType> _operationType;
		private NodeRef _nodeRef;

		[Ordinal(0)] 
		[RED("stimType")] 
		public CEnum<DeviceStimType> StimType
		{
			get => GetProperty(ref _stimType);
			set => SetProperty(ref _stimType, value);
		}

		[Ordinal(1)] 
		[RED("lifeTime")] 
		public CFloat LifeTime
		{
			get => GetProperty(ref _lifeTime);
			set => SetProperty(ref _lifeTime, value);
		}

		[Ordinal(2)] 
		[RED("radius")] 
		public CFloat Radius
		{
			get => GetProperty(ref _radius);
			set => SetProperty(ref _radius, value);
		}

		[Ordinal(3)] 
		[RED("operationType")] 
		public CEnum<EEffectOperationType> OperationType
		{
			get => GetProperty(ref _operationType);
			set => SetProperty(ref _operationType, value);
		}

		[Ordinal(4)] 
		[RED("nodeRef")] 
		public NodeRef NodeRef
		{
			get => GetProperty(ref _nodeRef);
			set => SetProperty(ref _nodeRef, value);
		}

		public SStimOperationData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
