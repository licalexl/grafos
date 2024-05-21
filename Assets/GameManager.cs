using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  private void Initialize() 
    {
      Node _node1 = new Node(val:3);
      Node _node2 = new Node(val:3);
      Node _node3 = new Node(val:2);
      Node _node4 = new Node(val:4);
      Node _node5 = new Node(val:5);
      Node _node6 = new Node(val:10);

        Edge edge13 = new Edge(one: ref _node1, two: ref _node3);

        _node1.AddEdge(ref edge13);
        _node3.AddEdge(ref edge13);

        Graph graph = new Graph();

        graph.AddNode(_node1);
    } 
}
