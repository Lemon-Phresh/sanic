using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emeraldController : MonoBehaviour
{
    public GameObject[] emerald, miniEmeralds;
    public GameObject miniPivot, eggman, emeraldParticle;
    public int speed;
    static public int emeralds;

    // Start is called before the first frame update
    void Start()
    {
        emeraldController.emeralds = 7;
    }

    // Update is called once per frame
    void Update()
    {

        miniPivot.transform.position = eggman.transform.position;
        miniPivot.transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    static public void LoseLife()
    {
        emeraldController thisScript = GameObject.Find("emeralds").GetComponent<emeraldController>();
        int x = 0;

        foreach(GameObject emer in thisScript.emerald)
        {
            if(!emer.activeSelf)
            {
                x++;
            }
        }
        GameObject[] activeEm = new GameObject[x];
        x = 0;
        foreach(GameObject emer in thisScript.emerald)
        {
            if(!emer.activeSelf)
            {
                activeEm[x] = emer;
                x++;
            }
        }
        int r = Random.Range(0, x);
        activeEm[r].SetActive(true);
        GameObject ep = Instantiate(thisScript.emeraldParticle, activeEm[r].transform.position, Quaternion.identity);
        Destroy(ep, 3f);
        emerald emeraldScr = activeEm[r].GetComponent<emerald>();
        emeraldScr.mini.SetActive(false);
        eggmanMove.modifier++;
        emeraldController.emeralds--;
    }

    public void ButtonScr()
    {
        int x = Random.Range(0, 3); //Max exclusive
        print (x);
    }
}
