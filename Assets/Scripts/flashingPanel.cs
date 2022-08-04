using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashingPanel : MonoBehaviour
{
    float t_;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        t_ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t_ = t_ + Time.deltaTime;

        if (t_ > 0.2f)
        {
            if(panel.activeSelf)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
            t_ = 0;
        }
    }
}
