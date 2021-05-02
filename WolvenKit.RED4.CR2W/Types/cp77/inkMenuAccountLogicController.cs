using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class inkMenuAccountLogicController : inkWidgetLogicController
	{
		private inkTextWidgetReference _playerId;
		private inkTextWidgetReference _changeAccountLabelTextRef;
		private inkWidgetReference _inputDisplayControllerRef;
		private CBool _changeAccountEnabled;

		[Ordinal(1)] 
		[RED("playerId")] 
		public inkTextWidgetReference PlayerId
		{
			get => GetProperty(ref _playerId);
			set => SetProperty(ref _playerId, value);
		}

		[Ordinal(2)] 
		[RED("changeAccountLabelTextRef")] 
		public inkTextWidgetReference ChangeAccountLabelTextRef
		{
			get => GetProperty(ref _changeAccountLabelTextRef);
			set => SetProperty(ref _changeAccountLabelTextRef, value);
		}

		[Ordinal(3)] 
		[RED("inputDisplayControllerRef")] 
		public inkWidgetReference InputDisplayControllerRef
		{
			get => GetProperty(ref _inputDisplayControllerRef);
			set => SetProperty(ref _inputDisplayControllerRef, value);
		}

		[Ordinal(4)] 
		[RED("changeAccountEnabled")] 
		public CBool ChangeAccountEnabled
		{
			get => GetProperty(ref _changeAccountEnabled);
			set => SetProperty(ref _changeAccountEnabled, value);
		}

		public inkMenuAccountLogicController(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
