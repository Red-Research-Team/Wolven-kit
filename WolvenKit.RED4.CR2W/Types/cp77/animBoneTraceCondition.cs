using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animBoneTraceCondition : ISerializable
	{
		private CInt16 _boneIndex;
		private CBool _traceByRotation;
		private CFloat _rotationAngleTolerance;
		private CBool _traceByTranslation;
		private CFloat _translationTolerance;

		[Ordinal(0)] 
		[RED("boneIndex")] 
		public CInt16 BoneIndex
		{
			get => GetProperty(ref _boneIndex);
			set => SetProperty(ref _boneIndex, value);
		}

		[Ordinal(1)] 
		[RED("traceByRotation")] 
		public CBool TraceByRotation
		{
			get => GetProperty(ref _traceByRotation);
			set => SetProperty(ref _traceByRotation, value);
		}

		[Ordinal(2)] 
		[RED("rotationAngleTolerance")] 
		public CFloat RotationAngleTolerance
		{
			get => GetProperty(ref _rotationAngleTolerance);
			set => SetProperty(ref _rotationAngleTolerance, value);
		}

		[Ordinal(3)] 
		[RED("traceByTranslation")] 
		public CBool TraceByTranslation
		{
			get => GetProperty(ref _traceByTranslation);
			set => SetProperty(ref _traceByTranslation, value);
		}

		[Ordinal(4)] 
		[RED("translationTolerance")] 
		public CFloat TranslationTolerance
		{
			get => GetProperty(ref _translationTolerance);
			set => SetProperty(ref _translationTolerance, value);
		}

		public animBoneTraceCondition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
