using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Answer_maru : MonoBehaviour
{
    [HideInInspector] public bool correct;
    public GameObject batu;
    bool start;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Collider>().isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Event_Panel.eventFlag)
        {
            if (!start)
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            start = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (correct)
            {
                Debug.Log("ê≥â");
                Sound_SE.playsound(0, 2);
            }
            else
            {
                Debug.Log("ïsê≥â");
                Sound_SE.playsound(0, 3);
            }
            batu.gameObject.GetComponent<Collider>().isTrigger = false;
            gameObject.GetComponent<Collider>().isTrigger = false;
            start = true;
        }
    }
}
