using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class AICommand : IScriptable
	{
		private CUInt32 _id;
		private CEnum<AICommandState> _state;
		private CUInt64 _questBlockId;
		private CName _category;

		[Ordinal(0)] 
		[RED("id")] 
		public CUInt32 Id
		{
			get => GetProperty(ref _id);
			set => SetProperty(ref _id, value);
		}

		[Ordinal(1)] 
		[RED("state")] 
		public CEnum<AICommandState> State
		{
			get => GetProperty(ref _state);
			set => SetProperty(ref _state, value);
		}

		[Ordinal(2)] 
		[RED("questBlockId")] 
		public CUInt64 QuestBlockId
		{
			get => GetProperty(ref _questBlockId);
			set => SetProperty(ref _questBlockId, value);
		}

		[Ordinal(3)] 
		[RED("category")] 
		public CName Category
		{
			get => GetProperty(ref _category);
			set => SetProperty(ref _category, value);
		}

		public AICommand(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
