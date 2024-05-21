using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    private List<Node> nodes = new List<Node>();

    public Graph() 
    {
    
    }

    public void AddNode(Node newnode) 
    {
      nodes.Add(newnode);
    }


    public Graph(ref List<Node> listNodes)
    {
        nodes = listNodes;
    }
}
