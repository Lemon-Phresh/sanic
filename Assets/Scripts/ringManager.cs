using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringManager : MonoBehaviour
{
    public GameObject[] spawners;
    public float t_;

    // Start is called before the first frame update
    void Start()
    {
        t_ = 30;
    }

    // Update is called once per frame
    void Update()
    {
        t_ = t_ - Time.deltaTime;

        if(t_ <= 0)
        {
            t_ = 30;
            foreach(GameObject spawner in spawners)
            {
                ringSpawn spawnScript = spawner.GetComponent<ringSpawn>();
                spawnScript.Spawn();
            }
        }
    }
}
