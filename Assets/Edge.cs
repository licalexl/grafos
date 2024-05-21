using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Edge 
{
    private Node _num1;
    private Node _num2;
    private float _distance;

    public Edge(ref Node one, ref Node two) 
    { 
      _num1 = one;
      _num2 = two;
    }
    public Node SetNum1(ref Node _node1)
    {
        return _node1;
    }
    public Node GetNum1() 
    {
      return  _num1;
    }

    public Node SetNum2(ref Node node2)
    {
        return node2;
    }
    public Node GetNum2()
    {
        return _num2;
    }

    
}
