using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPFollow : MonoBehaviour
{
    Transform goal;
    float speed = 5;
    float accuracy = 1;
    float rotSpeed = 2;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject[] currentNode;
    int currentWp = 0;
    Graph g;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wps = wpManager.GetComponent<WPManager[]>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];
    }
    public void GoToMontains()
    {
        g.AStar(currentNode, wps[0]);
        currentWp = 0;
    }

    public void GoToRuins()
    {
        g.AStar(currentNode, wps[1]);
        currentWp = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
