using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer SRenderer;
    [SerializeField] private NodeStates _nodeState;
    [SerializeField] List<NodeScript> _nextNodes;
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
                    SRenderer.color = Color.green; OpenNextNodes(); break;
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
    /// <summary>
    /// Update dependent nodes if this node change it's state from open to complete
    /// </summary>
    private void OpenNextNodes() 
    {
        if (NodeState!=NodeStates.Complete) return;

        foreach (var node in _nextNodes)
        {
            if (node == null)
            {
                Debug.LogWarning("Null reference to next node/s",this);
            }

            node.NodeState = NodeStates.Open;
        }
    }
    /// <summary>
    /// User interface to change node from Open to Complete
    /// </summary>
    private void OnMouseDown()
    {
        if (NodeState == NodeStates.Open)
        {
            NodeState = NodeStates.Complete;
        }
    }
    /// <summary>
    /// Recursive function that draws LineRenderers on the screen. They representate connection of the nodes
    /// </summary>
    public void DrawConnections()
    {
        foreach (var node in _nextNodes)
        {
            if (node == null) return;
            
            var Line = Instantiate<LineRenderer>(NodeMapSceneManager.Instance.ConnectionLine);
            Line.SetPositions(new Vector3[] { transform.position,node.transform.position });
            node.DrawConnections();
        }
    }
}

public enum NodeStates
{
    Locked,
    Open,
    Complete
}
