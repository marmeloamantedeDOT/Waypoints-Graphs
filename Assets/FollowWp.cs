using UnityEngine;

public class FollowWp : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWp = 0;

    public float speed = 10;
    public float rotspeed = 10;
    public float lookAhead = 10;

    GameObject tracker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }

    void ProgressTracker()
    {
        if (Vector3.Distance(tracker.transform.position, this.transform.position) > lookAhead) return;

            if (Vector3.Distance(tracker.transform.position, waypoints[currentWp].transform.position) < 10)
            currentWp++;
        if (currentWp >= waypoints.Length)
            currentWp = 0;
        tracker.transform.LookAt(waypoints[currentWp].transform);
        tracker.transform.Translate(0, 0, (speed + 5) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        ProgressTracker();

        //this.transform.LookAt(waypoints[currentWp].transform);
        Quaternion lookatWp = Quaternion.LookRotation(waypoints[currentWp].transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWp, rotspeed * Time.deltaTime);
        this.transform.Translate(0,0, speed * Time.deltaTime); 
    }
}
