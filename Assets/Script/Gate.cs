using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject eventPanel;
    public GameObject fire;
    Vector3 posi;

    bool open, close;

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
            Sound_SE.playsound(0, 0);
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
