using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Answer_batu : MonoBehaviour
{
    [HideInInspector] public bool correct;
    public GameObject maru;
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
                Debug.Log("正解");
                Sound_SE.playsound(0, 2);
            }
            else
            {
                Debug.Log("不正解");
                Sound_SE.playsound(0, 3);
            }
            maru.gameObject.GetComponent<Collider>().isTrigger = false;
            gameObject.GetComponent<Collider>().isTrigger = false;
            start = true;
        }
    }
}
