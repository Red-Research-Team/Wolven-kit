using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class inkComboBoxObjectController : inkWidgetLogicController
	{
		private inkWidgetReference _contentWidgetRef;
		private inkWidgetReference _placeholderOffsetWidgetRef;
		private inkShapeWidgetReference _colliderRef;
		private inkMargin _offset;

		[Ordinal(1)] 
		[RED("contentWidgetRef")] 
		public inkWidgetReference ContentWidgetRef
		{
			get => GetProperty(ref _contentWidgetRef);
			set => SetProperty(ref _contentWidgetRef, value);
		}

		[Ordinal(2)] 
		[RED("placeholderOffsetWidgetRef")] 
		public inkWidgetReference PlaceholderOffsetWidgetRef
		{
			get => GetProperty(ref _placeholderOffsetWidgetRef);
			set => SetProperty(ref _placeholderOffsetWidgetRef, value);
		}

		[Ordinal(3)] 
		[RED("colliderRef")] 
		public inkShapeWidgetReference ColliderRef
		{
			get => GetProperty(ref _colliderRef);
			set => SetProperty(ref _colliderRef, value);
		}

		[Ordinal(4)] 
		[RED("offset")] 
		public inkMargin Offset
		{
			get => GetProperty(ref _offset);
			set => SetProperty(ref _offset, value);
		}

		public inkComboBoxObjectController(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
