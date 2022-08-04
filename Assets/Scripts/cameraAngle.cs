using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAngle : MonoBehaviour
{
    public GameObject target, camera_;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target.GetComponent<eggmanMove>().alive)
        {
            transform.position = target.transform.position;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, speed * Time.deltaTime);
    }
}
