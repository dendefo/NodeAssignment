using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer SRenderer;
    [SerializeField] private NodeStates _nodeState;
    [SerializeField] List<NodeScript> _dependentNodes;
    public NodeStates NodeState
    {
        get { return _nodeState; }
        set
        {
            _nodeState = value;
            switch (_nodeState)
            {
                case NodeStates.Locked:
                    SRenderer.color = Color.grey; break;
                case (NodeStates.Open):
                    SRenderer.color = Color.yellow; break;
                case (NodeStates.Complete):
                    SRenderer.color = Color.green; Complete(); break;
            }
        }
    }

    /// <summary>
    /// To update the visual representation on changing value in inspector (Level design and debug only)
    /// </summary>
    private void OnValidate()
    {
        NodeState = _nodeState;
    }
    private void Complete()
    {
        foreach (var node in _dependentNodes)
        {
            node.NodeState = NodeStates.Open;
        }
    }
    private void OnMouseDown()
    {
        if (NodeState == NodeStates.Open)
        {
            NodeState = NodeStates.Complete;
        }
    }
}

public enum NodeStates
{
    Locked,
    Open,
    Complete
}
