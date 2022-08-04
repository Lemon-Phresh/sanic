using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringSpawn : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject ringPrefab;
    public GameObject ringParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Spawn()
    {
        foreach(GameObject p in spawnPoints)
        {
            point pt = p.GetComponent<point>();
            if (!pt.ring)
            {
                GameObject ring = Instantiate(ringPrefab, p.transform.position, Quaternion.Euler(90, 0, 0));
                GameObject particle = Instantiate(ringParticle, p.transform.position, Quaternion.identity);
                Destroy(particle, 2f);
                pt.ring = ring;
            }
        }
        print ("spawnedRings");
    }
}
