using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    private List<Node> nodes = new List<Node>();

    public Graph()
    {
        nodes = new List<Node>();
    }

    public Graph(ref List<Node> listNodes)
    {
        nodes = listNodes;
    }

    public void AddNode(Node newNode)
    {
        nodes.Add(newNode);
    }

    public List<Node> GetNodes()
    {
        return nodes;
    }

    public void DFS(Node n) 
    {
    
    
    }
    /*
    public void BFS(Node n)
    {
        foreach (Edge edge in n.GetEdges()) 
        {

            if (edge.Node1() == n)
                {
            
            
            }
        
        }

    }*/

    /*
    public List<Node> GetNodesToVisit(Node n) 
    {
    
      List<Node> nodesToVisit = new list<Node>();
    
    }*/
}
