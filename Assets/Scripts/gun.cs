using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public OVRInput.Controller ct;
    public GameObject bullet;
    public AudioClip sgunshot;
    public AudioClip rload;
    public AudioClip empty;
    public Transform bullet_hole;
    public float bullet_speed = 10f;
    public int ammo = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && ammo > 0)
        //{
        //    GameObject b = Instantiate<GameObject>(bullet);
        //    b.transform.position = bullet_hole.position;
        //    b.transform.rotation = bullet_hole.rotation;
        //    Rigidbody b_rb = b.GetComponent<Rigidbody>();
        //    b_rb.AddForce(b.transform.up * bullet_speed);

        //    ammo = ammo -1;
        //} 
        

    }

    public void shoot()
        {
        if(ammo > 0)
        {
            GameObject b = Instantiate<GameObject>(bullet);
            b.transform.position = bullet_hole.position;
            b.transform.rotation = bullet_hole.rotation;
            Rigidbody b_rb = b.GetComponent<Rigidbody>();
            GetComponent<AudioSource>().PlayOneShot(sgunshot, 0.5f);
            b_rb.AddForce(b.transform.up * bullet_speed);

            

            ammo = ammo - 1;
        }

        if (ammo == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(empty, 0.5f);
        }
            
        }
     
    public void reload()
    {
        GetComponent<AudioSource>().PlayOneShot(rload, 0.5f);
        ammo = 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null && collision.gameObject.CompareTag("mag") && ammo != 10)
        {
            reload();
            Destroy(collision.gameObject.GetComponent<PickupObject>());
            //collision.gameObject.GetComponent<mag>().makevisible();

            Destroy(collision.gameObject);
        }
    }


}
