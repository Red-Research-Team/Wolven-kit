using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimFeature_MeleeIKData : animAnimFeature
	{
		private CBool _isValid;
		private Vector4 _headPosition;
		private Vector4 _chestPosition;
		private Vector4 _ikOffset;

		[Ordinal(0)] 
		[RED("isValid")] 
		public CBool IsValid
		{
			get => GetProperty(ref _isValid);
			set => SetProperty(ref _isValid, value);
		}

		[Ordinal(1)] 
		[RED("headPosition")] 
		public Vector4 HeadPosition
		{
			get => GetProperty(ref _headPosition);
			set => SetProperty(ref _headPosition, value);
		}

		[Ordinal(2)] 
		[RED("chestPosition")] 
		public Vector4 ChestPosition
		{
			get => GetProperty(ref _chestPosition);
			set => SetProperty(ref _chestPosition, value);
		}

		[Ordinal(3)] 
		[RED("ikOffset")] 
		public Vector4 IkOffset
		{
			get => GetProperty(ref _ikOffset);
			set => SetProperty(ref _ikOffset, value);
		}

		public animAnimFeature_MeleeIKData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
