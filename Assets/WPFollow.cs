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
    GameObject currentNode;
    int currentWp = 0;
    Graph g;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];

        //Time.timeScale = 5.0f; NÃO SEI OQ É
        //Invoke("GotoRuins", 2);
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

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[4]);
        currentWp = 0;
    }


    // bool debbuged = false;  +1



    // Update is called once per frame
    void LateUpdate()
    {
        if (g.pathList.Count == 0 || currentWp == g.pathList.Count)
            return;

        /*if (!debbuged)
        {

            Debug.Log(g.pathList.Count);
            debbuged = true;
        }*/

        if (Vector3.Distance(g.pathList[currentWp].getId().transform.position, this.transform.position) < accuracy) 
           
                {
            currentNode = g.pathList[currentWp].getId();
            currentWp++;
        }

        if (currentWp < g.pathList.Count)
        {
            goal = g.pathList[currentWp].getId().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
