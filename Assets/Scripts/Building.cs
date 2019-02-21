using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject explosion;
    public GameObject next_building;
    public AudioClip exp;
    GameObject manager;
    // Start is called before the first frame update
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

            manager = GameObject.Find("Game Manager");
            manager.GetComponent<manager>().flife = manager.GetComponent<manager>().flife - 1f;

            GameObject xplod = Instantiate<GameObject>(explosion);
            xplod.transform.position = this.transform.position;

            GameObject nb = Instantiate<GameObject>(next_building);
            nb.transform.position = this.transform.position;
            nb.transform.rotation = this.transform.rotation;
            Destroy(this.gameObject);

        }
        
    }
}
