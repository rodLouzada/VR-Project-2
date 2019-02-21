using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public float spawn_rate_sec = 2f;
    public float dificulty_increase = 4f;
    float spawn_radius = 0.5f;
    float last_time;
    float dificult_time;
    public Transform spawn_origin;
    public GameObject rocket;
    public bool spawning=true;
    public bool the_end = false;

    public TextMesh score;
    public TextMesh life;

    public int iscore = 0;
    public float flife = 3f;
    float start_time;

    public GameObject text;
    public GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;
        last_time = Time.time;
        dificult_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - dificult_time > dificulty_increase)
        {
            spawn_rate_sec = spawn_rate_sec - 0.2f;
            dificult_time = Time.time;
        }
        if (Time.time - last_time > spawn_rate_sec && spawning)
        {
            GameObject r = Instantiate<GameObject>(rocket);

            r.transform.position = spawn_origin.position + Random.Range(-1.0f, 1.0f) * spawn_radius * spawn_origin.right +
                                                           Random.Range(-1.0f, 1.0f) * spawn_radius * spawn_origin.forward;

            last_time = Time.time;
        }
        if (the_end == true)
        {
            life.text = flife.ToString();
            restart_the_game();
        }else
        {
            iscore = Mathf.RoundToInt(Time.time - start_time);
            score.text = iscore.ToString();
            life.text = flife.ToString();
        }
        

        

    }

    void restart_the_game()
    {
        spawning = false;
        text.SetActive(true);
        btn.SetActive(true);

        



    }
}
