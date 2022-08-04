using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emerald : MonoBehaviour
{
    public int speed, no;
    public bool pickup;
    public GameObject mini;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mini.transform.Rotate(0, speed * Time.deltaTime, 0);
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
