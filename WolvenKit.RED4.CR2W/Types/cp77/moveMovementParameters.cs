using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class moveMovementParameters : CVariable
	{
		private CEnum<moveMovementType> _type;
		private CFloat _maxSpeed;
		private CFloat _acceleration;
		private CFloat _deceleration;
		private CFloat _rotationSpeed;

		[Ordinal(0)] 
		[RED("type")] 
		public CEnum<moveMovementType> Type
		{
			get => GetProperty(ref _type);
			set => SetProperty(ref _type, value);
		}

		[Ordinal(1)] 
		[RED("maxSpeed")] 
		public CFloat MaxSpeed
		{
			get => GetProperty(ref _maxSpeed);
			set => SetProperty(ref _maxSpeed, value);
		}

		[Ordinal(2)] 
		[RED("acceleration")] 
		public CFloat Acceleration
		{
			get => GetProperty(ref _acceleration);
			set => SetProperty(ref _acceleration, value);
		}

		[Ordinal(3)] 
		[RED("deceleration")] 
		public CFloat Deceleration
		{
			get => GetProperty(ref _deceleration);
			set => SetProperty(ref _deceleration, value);
		}

		[Ordinal(4)] 
		[RED("rotationSpeed")] 
		public CFloat RotationSpeed
		{
			get => GetProperty(ref _rotationSpeed);
			set => SetProperty(ref _rotationSpeed, value);
		}

		public moveMovementParameters(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
