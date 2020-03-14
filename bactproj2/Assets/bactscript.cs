using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bactscript : MonoBehaviour {

    float r, g, b;
    float speed;
    float size;
    float dupetime = 1.0f;
    float deletetime = 20.0f;
    bool isstart = true;

	// Use this for initialization
	void Start () {
        if (isstart)
        {
            r = Random.Range(0, 1.0f);
            g = Random.Range(0, 1.0f);
            b = Random.Range(0, 1.0f);

            speed = 10.0f;
            size = 10.0f;

            gameObject.GetComponent<Transform>().localScale.Set(size, size, size);

            gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b);
        }
	}

    void Start(float Rin, float Gin, float Bin, float Speedin, float Sizein)
    {
        r = Rin += Random.Range(-0.2f, 0.2f);
        g = Gin += Random.Range(-0.2f, 0.2f);
        b = Bin += Random.Range(-0.2f, 0.2f);
        speed = Speedin += Random.Range(-0.5f, 0.5f);
        // size = Sizein += Random.Range(-0.1f, 0.1f);
        size = Random.Range(-0.1f, 0.1f);


        gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b);
        gameObject.GetComponent<Transform>().localScale += new Vector3(size, size, size);



    }

    void Dupe()
    {


            Transform Tform = gameObject.transform;
            GameObject b2 = Instantiate(gameObject, new Vector3(Tform.transform.position.x + Random.Range(-1, 2), Tform.transform.position.y, Tform.transform.position.z + Random.Range(-1, 2)), Quaternion.identity, null);
            b2.GetComponent<bactscript>().isstart = false;
            b2.tag = "bact";
            b2.name = "bact";
            b2.GetComponent<bactscript>().Start(r, g, b, speed, size);
        


    }
	
	// Update is called once per frame
	void Update () {
        dupetime -= Time.deltaTime;
        deletetime -= Time.deltaTime;


            if (dupetime <= 0 && Random.Range(0, GameObject.FindGameObjectsWithTag("bact").Length + 1) == 1)
            {
                Dupe();
                dupetime = 1.0f;
            }

            if (deletetime <= 0)
            {
                Destroy(gameObject);
            }

	}


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "soap")
        {
            Destroy(gameObject);
        }

    }
}
