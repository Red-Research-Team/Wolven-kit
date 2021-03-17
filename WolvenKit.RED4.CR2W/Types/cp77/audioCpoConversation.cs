using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class audioCpoConversation : audioAudioMetadata
	{
		private CEnum<audioVoCpoCharacter> _characterOne;
		private CEnum<audioVoCpoCharacter> _characterTwo;
		private CArray<CName> _voTriggers;

		[Ordinal(1)] 
		[RED("characterOne")] 
		public CEnum<audioVoCpoCharacter> CharacterOne
		{
			get => GetProperty(ref _characterOne);
			set => SetProperty(ref _characterOne, value);
		}

		[Ordinal(2)] 
		[RED("characterTwo")] 
		public CEnum<audioVoCpoCharacter> CharacterTwo
		{
			get => GetProperty(ref _characterTwo);
			set => SetProperty(ref _characterTwo, value);
		}

		[Ordinal(3)] 
		[RED("voTriggers")] 
		public CArray<CName> VoTriggers
		{
			get => GetProperty(ref _voTriggers);
			set => SetProperty(ref _voTriggers, value);
		}

		public audioCpoConversation(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
