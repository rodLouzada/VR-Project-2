using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public AudioClip small_exp;
    public AudioClip jet;
    public GameObject explosion;
    AudioSource auso;
    // Start is called before the first frame update
    void Start()
    {
        
        
        GetComponent<AudioSource>().PlayOneShot(jet, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Stop();
        Destroy(this.gameObject);
        GameObject xplod = Instantiate<GameObject>(explosion);
        xplod.transform.position = this.transform.position;
        AudioSource.PlayClipAtPoint(small_exp, this.transform.position);
    }
}
