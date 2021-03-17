using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class genLevelRandomizerEntry : CVariable
	{
		private CString _id;
		private CName _templateName;
		private NodeRef _spawnPos;
		private CFloat _probability;

		[Ordinal(0)] 
		[RED("id")] 
		public CString Id
		{
			get => GetProperty(ref _id);
			set => SetProperty(ref _id, value);
		}

		[Ordinal(1)] 
		[RED("templateName")] 
		public CName TemplateName
		{
			get => GetProperty(ref _templateName);
			set => SetProperty(ref _templateName, value);
		}

		[Ordinal(2)] 
		[RED("spawnPos")] 
		public NodeRef SpawnPos
		{
			get => GetProperty(ref _spawnPos);
			set => SetProperty(ref _spawnPos, value);
		}

		[Ordinal(3)] 
		[RED("probability")] 
		public CFloat Probability
		{
			get => GetProperty(ref _probability);
			set => SetProperty(ref _probability, value);
		}

		public genLevelRandomizerEntry(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
