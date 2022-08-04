using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eggmanMove : MonoBehaviour
{
    static public int score, rings, modifier, highScore;
    public int acceleration, speed, rotation;
    public float countdown, mt_, ht_, gOt_;
    public Rigidbody rb;
    public GameObject bomb, minPivot, hitPanel, malfPanel;
    public bool alive, gO;

    static public Vector3 target;

    public GameObject hitParticle, emeraldPickup, ringPickup, bigExplosion;
    public Text scoreText, ringsText;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Bomb"));
        score = 0;
        rings = 0;
        modifier = 0;
        rb.AddForce(transform.forward * Time.deltaTime * acceleration);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gO)
        {
            gOt_ = gOt_ - Time.deltaTime;
            if(gOt_ < 0)
            {
                gameObject.GetComponent<finishGame>().FinishGame();
            }
        }
        if(alive)
        {
            if (malfPanel.activeSelf)
            {
                mt_ = mt_ - Time.deltaTime;
                if(mt_ < 0)
                {
                    malfPanel.SetActive(false);
                }
            }

            if(hitPanel.activeSelf)
            {
                ht_ = ht_ - Time.deltaTime;
                if(ht_ < 0)
                {
                    hitPanel.SetActive(false);
                }
            }

            scoreText.text = $"Score - {score}";
            ringsText.text = $"Rings - {rings}";

            countdown = countdown - Time.deltaTime;
            speed = ((7 - emeraldController.emeralds) * 3) + 10 + modifier;

            if (rb.velocity == Vector3.zero)
            {
            rb.AddForce(transform.forward * Time.deltaTime * acceleration);
            }
            
            rb.velocity = transform.forward.normalized * speed * Time.deltaTime * 100;


            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    if (rotation > -120)
                    {
                        rotation = rotation - 5;
                    }
                }
                if (rotation > -60)
                {
                    rotation = rotation - 5;
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    if (rotation < 120)
                    {
                        rotation = rotation + 5;
                    }
                }
                else
                {
                    if (rotation < 60)
                    {
                        rotation = rotation + 5;
                    }
                }
            }

            
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                if (rotation > 0)
                {
                    rotation = rotation - 5;
                }
                if (rotation < 0)
                {
                    rotation = rotation + 5;
                }
            }

            if (Input.GetButton("Fire1") && countdown < 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitData;
                if(Physics.Raycast(ray, out hitData, 1000))
                {
                    target = hitData.point;
                    if(hitData.collider.tag == "Wall")
                    {
                        Vector3 pos = new Vector3(hitData.point.x, -35, hitData.point.z);
                        Instantiate(bomb, transform.position, Quaternion.identity);
                        countdown  = 1.5f;
                    }
                }
            }

            if(emeraldController.emeralds == 0)
            {
                alive = false;
                rb.useGravity = true;
                Physics.gravity = new Vector3(0, -8.0F, 0);
                rb.velocity = rb.velocity * 0.3f;
            }
        }

        transform.Rotate(0, rotation * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Target")
        {
            if (alive)
            {
            ContactPoint cp = coll.contacts[0];
            Vector3 reflection = Vector3.Reflect(transform.forward, cp.normal);
            float rot = Mathf.Atan2(reflection.x, reflection.z) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
            GameObject hit = Instantiate(hitParticle, cp.point, Quaternion.identity);
            hit.transform.parent = gameObject.transform;
            Destroy(hit, 1.5f);
            emeraldController.LoseLife();
            }
            else
            {
                GameObject exp = Instantiate(bigExplosion, transform.position, Quaternion.identity);
                Destroy(exp, 4f);
                gameObject.SetActive(false);
                gOt_ = 5f;
                gO = true;
            }
        }

        if(coll.gameObject.tag == "Emerald")
        {
            coll.gameObject.GetComponent<emerald>().mini.SetActive(true);
            coll.gameObject.SetActive(false);
            emeraldController.emeralds++;
            GameObject ep = Instantiate(emeraldPickup, coll.gameObject.transform.position, Quaternion.identity);
            Destroy(ep, 1.5f);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Ring")
        {
            rings++;
            Destroy(coll.gameObject);
            GameObject rp = Instantiate(ringPickup, coll.transform.position, Quaternion.identity);
            Destroy(rp, 1.5f);

            if ( rings != 0 && rings % 10 == 0 )
            {
                if (Random.Range(0, 3) == 0)
                {
                    emeraldController.LoseLife();
                    GameObject ep = Instantiate(hitParticle, transform.position, Quaternion.identity);
                    ep.transform.parent = gameObject.transform;
                    Destroy(ep, 2f);
                    malfPanel.SetActive(true);
                    mt_ = 1f;
                }
            }
        }
    }

    public void hitTextTurnOn()
    {
        
    }

    public void hitTextTurnOff()
    {

    }
}