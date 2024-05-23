using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject nodePrefab;
    public GameObject linePrefab;

    private List<GameObject> nodeGameObjects = new List<GameObject>();
    private List<GameObject> lineGameObjects = new List<GameObject>();

    void Start()
    {
        Creacion();
    }

    void Update()
    {

    }

    private void Creacion()
    {
        Node node1 = new Node(3);
        Node node2 = new Node(3);
        Node node3 = new Node(2);
        Node node4 = new Node(10);
        Node node5 = new Node(5);
        Node node6 = new Node(4);

        Edge edge1_2 = new Edge(ref node1, ref node2);
        Edge edge2_3 = new Edge(ref node2, ref node3);
        Edge edge2_1 = new Edge(ref node2, ref node1);
        Edge edge3_4 = new Edge(ref node3, ref node4);
        Edge edge3_2 = new Edge(ref node3, ref node2);
        Edge edge4_5 = new Edge(ref node4, ref node5);
        Edge edge4_3 = new Edge(ref node4, ref node3);
        Edge edge5_6 = new Edge(ref node5, ref node6);
        Edge edge5_2 = new Edge(ref node5, ref node2);

        node1.AddEdge(ref edge1_2);
        node2.AddEdge(ref edge2_3);
        node2.AddEdge(ref edge2_1);
        node3.AddEdge(ref edge3_4);
        node3.AddEdge(ref edge3_2);
        node4.AddEdge(ref edge4_5);
        node4.AddEdge(ref edge4_3);
        node5.AddEdge(ref edge5_6);
        node5.AddEdge(ref edge5_2);
        

        Graph graph = new Graph();
        graph.AddNode(node1);
        graph.AddNode(node2);
        graph.AddNode(node3);
        graph.AddNode(node4);
        graph.AddNode(node5);
        graph.AddNode(node6);

        HacerGrafito(graph);
    }

    private void HacerGrafito(Graph graph)
    {
        Dictionary<Node, GameObject> nodeObjectMap = new Dictionary<Node, GameObject>();

        foreach (Node node in graph.GetNodes())
        {
            Vector3 position = new Vector3(Random.Range(-50, 50), Random.Range(-30, 30),  Random.Range(-30, 30));
            GameObject nodeGO = Instantiate(nodePrefab, position, Quaternion.identity);
            nodeObjectMap[node] = nodeGO;
            nodeGameObjects.Add(nodeGO);
        }

        foreach (Node node in graph.GetNodes())
        {
            foreach (Edge edge in node.GetEdges())
            {
                if (!nodeObjectMap.ContainsKey(edge.Node1()) || !nodeObjectMap.ContainsKey(edge.Node2()))
                    continue;

                GameObject lineGO = Instantiate(linePrefab);

                Vector3 node1Position = nodeObjectMap[edge.Node1()].transform.position;
                Vector3 node2Position = nodeObjectMap[edge.Node2()].transform.position;

                Vector3 midpoint = (node1Position + node2Position) / 2;
                lineGO.transform.position = midpoint;

                Vector3 direction = node2Position - node1Position;
                lineGO.transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);

                float distance = Vector3.Distance(node1Position, node2Position);
                lineGO.transform.localScale = new Vector3(distance, 0.1f, 0.1f);

                lineGameObjects.Add(lineGO);
            }
        }
    }
}
