using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailsControl : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject target;

    public float smooth, speed;

    public UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[Random.Range(0, 5)];
        agent.destination = target.transform.position;
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Tails"), LayerMask.NameToLayer("Bomb"));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x == target.transform.position.x && transform.position.z == target.transform.position.z)
        {
            FindNewTarget();
        }
    }

    void FindNewTarget()
    {
        int r = target.GetComponent<tailsWaypoint>().no;
        while(r == target.GetComponent<tailsWaypoint>().no)
        {
            r = Random.Range(0, 5);
        }
        target = waypoints[r];
        agent.destination = target.transform.position;

    }
}
