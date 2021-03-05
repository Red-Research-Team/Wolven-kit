using NodeNetwork.ViewModels;

namespace WolvenKit.Functionality.WKitGlobal.Helpers
{
    public class CustomNode : NodeViewModel
    {
        //public Color nodecolor;

        //public CustomNode(
        //    string NodeName,
        //    Color NodeColor,
        //    string NodeDescription,
        //    string NodeFamily,

        //    List<ValueNodeInputViewModel<Type>> InputSockets,
        //    List<ValueNodeOutputViewModel<Type>> OutputSockets)
        //{
        //    this.Name = NodeName;
        //    nodecolor = NodeColor;

        //    foreach (var InSocket in InputSockets)
        //    {
        //        this.Inputs.Add(InSocket);
        //    }

        //    foreach (var OutSocket in OutputSockets)
        //    {
        //        this.Outputs.Add(OutSocket);
        //    }

        //}
    }

    public class NodeNetworkHelper
    {
        #region Enums

        public enum NodeType
        {
            StartNode, SceneNode, PhaseNode, InputNode,
            OutputNode, DeletionNode, PauseNode, InteractiveObjectManagerNode,
            DeviceManagerNode, ConditionNode, QuestNode, HubNode,
            EndNode, ChoiceNode, SectionNode, RandomizerNode,
            XorNode, FactsDBManagerNode, LogicalHubNode, WorldDataManagerNode,
            AudioNode, TeleportPuppetNode, UIManagerNode, RenderFXNode,
            LogicalXorNode, RewardManagerNode, CheckpointNode, CharacterManagerNode,
            PhoneManagerNode, CutControlNode,
        }

        #endregion Enums

        #region Classes

        public class Node_Template
        {
            //  public string Name;
            //  public Color Color;
            //  public List<NodeType> Sockets = new List<NodeType>();
        }

        #endregion Classes
    }
}
