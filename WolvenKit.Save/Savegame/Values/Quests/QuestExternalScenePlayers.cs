using WolvenKit.W3SavegameEditor.Core.Savegame.Attributes;

namespace WolvenKit.W3SavegameEditor.Core.Savegame.Values.Quests
{
    [CSerializable("questExternalScenePlayers")]
    public class QuestExternalScenePlayers
    {
        #region Constructors

        public QuestExternalScenePlayers()
        {
        }

        #endregion Constructors

        #region Properties

        [CName("")]
        public QuestExternalScenePlayer QuestExternalScenePlayer1 { get; set; }

        [CName("")]
        public QuestExternalScenePlayer QuestExternalScenePlayer2 { get; set; }

        #endregion Properties
    }
}
