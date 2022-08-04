using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject explosion, sonic, sonicPivot;
    

    // Start is called before the first frame update
    void Awake()
    {
        sonic = GameObject.Find("sonic");
        sonicPivot = GameObject.Find("sonicPivot");
        Rigidbody rigid = GetComponent<Rigidbody>();
        Vector3 target = eggmanMove.target;
        float initialAngle = 15f;
 
        float gravity = Physics.gravity.magnitude;
        // Selected angle in radians
        float angle = initialAngle * Mathf.Deg2Rad;

        // Positions of this object and the target on the same plane
        Vector3 planarTarget = new Vector3(target.x, 0, target.z);
        Vector3 planarPostion = new Vector3(transform.position.x, 0, transform.position.z);

        // Planar distance between objects
        float distance = Vector3.Distance(planarTarget, planarPostion);
        // Distance along the y axis between objects
        float yOffset = transform.position.y - target.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));
 
        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        // Rotate our velocity to match the direction between the two objects
        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion) * (target.x > transform.position.x ? 1 : -1);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        rigid.velocity = finalVelocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Target")
        {
            ContactPoint cp = coll.contacts[0];
            GameObject particle = Instantiate(explosion, transform.position, Quaternion.identity);
            if (Vector3.Distance(sonic.transform.position, transform.position) < 15f)
            {
                print (Vector3.Distance(sonic.transform.position, transform.position));
                sonicPivot.GetComponent<sonicMove>().backwards = !sonicPivot.GetComponent<sonicMove>().backwards;
                eggmanMove.score = eggmanMove.score + eggmanMove.rings;
                eggmanMove.modifier++;
                GameObject.Find("eggmanNew").GetComponent<eggmanMove>().hitPanel.SetActive(true);
            }
            Destroy(particle, 0.5f);
            Destroy(this.gameObject);
        }
    }

    
}
