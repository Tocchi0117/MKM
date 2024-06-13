using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Answer_batu : MonoBehaviour
{
    [HideInInspector] public bool correct;
    public GameObject eventPanel,maru;
    bool open, close;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (eventPanel.GetComponent<EventPanel>().flag)
        {
            if (!open)
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
            maru.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
