using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class scannerDataStructure : CVariable
	{
		private CString _entityName;
		private CString _quickHackName;
		private CString _quickHackDesc;
		private CArray<scannerQuestEntry> _questEntries;
		private CBool _empty;

		[Ordinal(0)] 
		[RED("entityName")] 
		public CString EntityName
		{
			get => GetProperty(ref _entityName);
			set => SetProperty(ref _entityName, value);
		}

		[Ordinal(1)] 
		[RED("quickHackName")] 
		public CString QuickHackName
		{
			get => GetProperty(ref _quickHackName);
			set => SetProperty(ref _quickHackName, value);
		}

		[Ordinal(2)] 
		[RED("quickHackDesc")] 
		public CString QuickHackDesc
		{
			get => GetProperty(ref _quickHackDesc);
			set => SetProperty(ref _quickHackDesc, value);
		}

		[Ordinal(3)] 
		[RED("questEntries")] 
		public CArray<scannerQuestEntry> QuestEntries
		{
			get => GetProperty(ref _questEntries);
			set => SetProperty(ref _questEntries, value);
		}

		[Ordinal(4)] 
		[RED("empty")] 
		public CBool Empty
		{
			get => GetProperty(ref _empty);
			set => SetProperty(ref _empty, value);
		}

		public scannerDataStructure(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
