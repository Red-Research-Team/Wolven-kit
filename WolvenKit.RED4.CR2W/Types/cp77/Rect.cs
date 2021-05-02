using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class Rect : CVariable
	{
		private CInt32 _left;
		private CInt32 _top;
		private CInt32 _right;
		private CInt32 _bottom;

		[Ordinal(0)] 
		[RED("left")] 
		public CInt32 Left
		{
			get => GetProperty(ref _left);
			set => SetProperty(ref _left, value);
		}

		[Ordinal(1)] 
		[RED("top")] 
		public CInt32 Top
		{
			get => GetProperty(ref _top);
			set => SetProperty(ref _top, value);
		}

		[Ordinal(2)] 
		[RED("right")] 
		public CInt32 Right
		{
			get => GetProperty(ref _right);
			set => SetProperty(ref _right, value);
		}

		[Ordinal(3)] 
		[RED("bottom")] 
		public CInt32 Bottom
		{
			get => GetProperty(ref _bottom);
			set => SetProperty(ref _bottom, value);
		}

		public Rect(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
