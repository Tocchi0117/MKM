using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Answer_batu : MonoBehaviour
{
    [HideInInspector] public bool correct;
    public GameObject eventPanel, maru, jama;
    bool open, close;

    public static int cnt;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        jama.SetActive(false);
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
                cnt = 0;
            }
        }
        else
        {
            if (!close)
            {
                open = false;
                close = true;
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
                jama.SetActive(false);
            }
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
                cnt++;
            }
            else
            {
                Debug.Log("ïsê≥â");
                Sound_SE.playsound(0, 3);
                jama.SetActive(true);
            }
            maru.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
