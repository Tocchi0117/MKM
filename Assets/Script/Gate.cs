using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject fire;
    Vector3 posi;

    bool start;

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
        if (Event_Panel.eventFlag)
        {
            if(!start)
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
        else
        {
            fire.SetActive(false);
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            FireMove.flag = false;
            start = false;
            fire.transform.position = posi;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fire.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            start = true;
            Sound_SE.playsound(0,0);
        }
    }
}
