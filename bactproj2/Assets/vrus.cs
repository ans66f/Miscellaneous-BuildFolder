using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrus : MonoBehaviour {

    Vector3 direction;
    bool stealthmode = false;
    float stealthtimer = 20.0f;

	// Use this for initialization
	void Start () {
        stealthtimer = Random.Range(15, 30);
        gameObject.tag = "vrus";
        direction = new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f));

	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Transform>().Translate(direction);


        if(stealthmode)
        {
            stealthtimer -= Time.deltaTime;
        }
        else
        {
           
        }

        if(stealthtimer <= 0)
        {
            stealthmode = false;
            gameObject.GetComponent<Transform>().localScale = new Vector3(0.1609643f, 0.1609643f, 0.1609643f);
            direction = new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f));
            stealthtimer = Random.Range(15, 30);
            gameObject.name = "vrus";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bact")
        {
            if (Random.Range(0, 100) == 1)
            {
                Destroy(collision.gameObject);
                direction = new Vector3(0, 0, 0);
                stealthmode = true;
                gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                gameObject.tag = "vrusS";
                gameObject.name = "vrus(stealth)";
            }
            if (!stealthmode)
            {
                Destroy(collision.gameObject);
                GameObject v2 = Instantiate(gameObject, gameObject.GetComponent<Transform>().position, Quaternion.identity, null);
                gameObject.tag = "vrus";
                v2.name = "vrus";
            }
            else
            {


            }
        }
        if ((collision.gameObject.tag == "bactI") && stealthmode)
        {
            Destroy(collision.gameObject);

            stealthtimer = Random.Range(15, 30);
        }
        if ((collision.gameObject.tag == "wall") && !stealthmode)
        {
            gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            direction = new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f));
            gameObject.GetComponent<Transform>().localScale = new Vector3(0.1609643f, 0.1609643f, 0.1609643f);
        }
        if ((collision.gameObject.tag == "soap"))
        {
            Destroy(gameObject);
        }
    }
}
