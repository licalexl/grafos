using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

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

        instaciarNodos(graph);
    }

    private void HacerGrafito(Graph graph, Dictionary<Node, GameObject> instanciaNodosObject)
    {

        foreach (Node node in graph.GetNodes())
        {
            foreach (Edge edge in node.GetEdges())
            {
                if (!instanciaNodosObject.ContainsKey(edge.Node1()) || !instanciaNodosObject.ContainsKey(edge.Node2()))
                    continue;

                GameObject objectoLinea = Instantiate(linePrefab);

                Vector3 pos1N = instanciaNodosObject[edge.Node1()].transform.position;


                Vector3 pos2N = instanciaNodosObject[edge.Node2()].transform.position;

                Vector3 puntoIntermedio = (pos1N + pos2N) / 2;


                objectoLinea.transform.position = puntoIntermedio;

                Vector3 direction = pos2N - pos1N;

                objectoLinea.transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);


                float distancia = Vector3.Distance(pos1N, pos2N);

                objectoLinea.transform.localScale = new Vector3(distancia, 0.1f, 0.1f);

                lineGameObjects.Add(objectoLinea);
            }
        }
    }


    private void instaciarNodos(Graph graph)
    {
        Dictionary<Node, GameObject> instanciaNodosObject = new Dictionary<Node, GameObject>();

        foreach (Node node in graph.GetNodes())
        {
            Vector3 position = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
            GameObject iniciarNodos = Instantiate(nodePrefab, position, Quaternion.identity);
            instanciaNodosObject[node] = iniciarNodos;
            nodeGameObjects.Add(iniciarNodos);
        }

        HacerGrafito(graph, instanciaNodosObject);
    }
}
