using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject eventPanel;
    public GameObject fire;
    public bool start, goal;


    Vector3 posi;
    bool open, close;

    static DateTime STime;

    public static float time;

    // Start is called before the first frame update
    void Start()
    {
        posi = fire.transform.position;
        fire.SetActive(false);
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (eventPanel.GetComponent<EventPanel>().flag)
        {
            if(!open)
            {
                open = true;
                close = false;
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
        else
        {
            if (!close)
            {
                fire.SetActive(false);
                FireMove.flag = false;
                fire.transform.position = posi;

                open = false;
                close = true;
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (start)
            {
                fire.SetActive(true);
                Sound_SE.playsound(0, 0);

                STime = DateTime.Now;
            }

            if (goal)
            {
                fire.SetActive(false);
                Sound_SE.playsound(0, 0);

                time = (float)(DateTime.Now - STime).TotalSeconds;
            }

            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
