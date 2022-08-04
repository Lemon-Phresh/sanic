using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCam : MonoBehaviour
{
    public bool reversed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!reversed)
        {
        transform.Rotate(0, 0.5f, 0);
        }
        else
        {
            transform.Rotate(0, -0.5f, 0);
        }
    }
}
