using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fung : MonoBehaviour {
    float age = 0;
    float size = 1;
    float lsize = 0;
    int damage = 0;
    bool isspore = false;
    float sporeinvincibletimer = 1.0f;
    float sporetimer = 10.0f;
    Vector3 direction = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0);

    }
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Transform>().Translate(direction);
        sporetimer -= Time.deltaTime;
        sporeinvincibletimer -= Time.deltaTime;

        if (age >= 30) age = 30;

        if (!isspore)
        {
            age += Time.deltaTime;
            size = (age + 2) - damage;
            lsize = Mathf.Log(size);
            gameObject.GetComponent<Transform>().localScale = new Vector3(lsize, 1, lsize);


            if (damage > age)
            {
                Destroy(gameObject);
            }

            if (sporetimer <= 0)
            {
                int i = 0;
                for (i = 0; i < 40 - GameObject.FindGameObjectsWithTag("fung").Length; i++)
                {
                    GameObject sp = Instantiate(gameObject, gameObject.GetComponent<Transform>().position, Quaternion.identity, null);
                    sp.GetComponent<fung>().isspore = true;
                    sp.name = "fung(spore)";
                    sp.GetComponent<fung>().direction = new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f));
                    sp.GetComponent<fung>().sporetimer = Random.Range(2, 8);
                }
                sporetimer = 10.0f;
            }
        }
        else
        {
            gameObject.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.1f, 0.2f);
            if (sporetimer <= 0)
            {
                if (Random.Range(0, GameObject.FindGameObjectsWithTag("fung").Length + 20) == 1)
                {
                    gameObject.name = "fung";
                    isspore = false;
                    direction = new Vector3(0, 0, 0);
                    sporetimer = 20.0f;
                    age = 2.0f;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isspore)
        {

            if (collision.gameObject.tag == "vrus" || collision.gameObject.tag == "vrusS" || collision.gameObject.tag == "soap" || collision.gameObject.tag == "fung")
            {
                damage += 1;
                Destroy(collision.gameObject);
            }
        }
        else
        {
            if (sporeinvincibletimer <= 0)
            {
                Destroy(gameObject);
            }
           
        }
    }
}
