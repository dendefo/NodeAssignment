using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMapSceneManager : MonoBehaviour
{
    //Simplified singleton for using some assets (may be also used for providing diffent sprites for node states
    //It is more data efficient approach, when those sprites saved in one place instead of each node
    [SerializeField] NodeScript _startingNode;
    public  LineRenderer ConnectionLine;
    public static NodeMapSceneManager Instance; 

    void Start()
    {
        Instance = this;
        _startingNode.DrawConnections();
    }
}
