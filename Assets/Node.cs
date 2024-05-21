using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    private bool _visited;
    private float _value;

    private List<Edge> _edge;

    public Node()
    {
        _visited = false;
        _value = 0;
        _edge = new List<Edge>();
    }
    public Node(float val) 
    {
      _visited = false;
      _value = 0;
      _edge = new List<Edge>();
    }   

    public void addValue(ref Edge edge) 
    { 
      _edge.Add(edge);
    }

    public void SetVisited(bool visited)
    {
        _visited=visited;
    }

    public bool GetVisited()
    {
      return _visited;
    }
    public List<Edge> GetEdges() 
    { 
        return _edge; 
    }
}
