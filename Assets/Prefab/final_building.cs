using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final_building : MonoBehaviour
{
    public GameObject explosion;
     GameObject manager;
    public AudioClip exp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null && collision.gameObject.CompareTag("Rocket"))
        {
            GetComponent<AudioSource>().PlayOneShot(exp, 1f);

            GameObject xplod = Instantiate<GameObject>(explosion);
            xplod.transform.position = this.transform.position;

            manager  = GameObject.Find("Game Manager");
            manager.GetComponent<manager>().flife = manager.GetComponent<manager>().flife - 1f;
            manager.GetComponent<manager>().the_end = true;
            
            Destroy(this.gameObject);

        }

    }
}
