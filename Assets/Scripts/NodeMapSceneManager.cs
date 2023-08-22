using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMapSceneManager : MonoBehaviour
{
    [SerializeField] NodeScript _startingNode;
    public  LineRenderer ConnectionLine;
    public static NodeMapSceneManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        _startingNode.DrawConnections();
    }
}
