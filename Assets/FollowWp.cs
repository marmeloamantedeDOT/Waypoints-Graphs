using UnityEngine;

public class FollowWp : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWp = 0;

    public float speed = 10;
    public float rotspeed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWp].transform.position) < 10)
            currentWp++;

        if (currentWp >= waypoints.Length)
            currentWp = 0;

        //this.transform.LookAt(waypoints[currentWp].transform);
        Quaternion lookatWp = Quaternion.LookRotation(waypoints[currentWp].transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWp, rotspeed * Time.deltaTime);
        this.transform.Translate(0,0, speed * Time.deltaTime);
    }
}
