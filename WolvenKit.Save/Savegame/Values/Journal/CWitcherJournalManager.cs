using WolvenKit.W3SavegameEditor.Core.Savegame.Attributes;

namespace WolvenKit.W3SavegameEditor.Core.Savegame.Values.Journal
{
    public class CWitcherJournalManager /* : CJournalManager */
    {
        #region Properties

        [CName("JEntryAdvancedInfo")]
        public JEntryAdvancedInfo EntryAdvancedInfo { get; set; }

        [CName("JHighlightedObjective")]
        public JHighlightedObjective HighlightedObjective { get; set; }

        [CName("JHuntingClues")]
        public JHuntingClues HuntingClues { get; set; }

        [CName("JMonsterKnown")]
        public JMonsterKnown MonsterKnown { get; set; }

        [CName("JObjectiveCounters")]
        public JObjectiveCounters ObjectiveCounters { get; set; }

        [CName("JTrackedQuest")]
        public JTrackedQuest TrackedQuest { get; set; }

        #endregion Properties
    }
}
