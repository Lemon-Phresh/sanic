using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonicMove : MonoBehaviour
{
    public GameObject sonic, eggman;
    public int speed;
    public bool backwards;

    // Start is called before the first frame update
    void Start()
    {
        backwards = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(eggman.GetComponent<eggmanMove>().alive)
        {
            float r = speed * Time.deltaTime;
            if(backwards)
            {
                sonic.transform.localRotation = Quaternion.Euler(0, 180, 0);
                r = r * -1;
            }
            else
            {
                sonic.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            transform.Rotate(0, r, 0);
        }
    }
}
