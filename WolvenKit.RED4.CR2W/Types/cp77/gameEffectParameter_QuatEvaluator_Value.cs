using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameEffectParameter_QuatEvaluator_Value : gameIEffectParameter_QuatEvaluator
	{
		private Quaternion _value;

		[Ordinal(0)] 
		[RED("value")] 
		public Quaternion Value
		{
			get => GetProperty(ref _value);
			set => SetProperty(ref _value, value);
		}

		public gameEffectParameter_QuatEvaluator_Value(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
