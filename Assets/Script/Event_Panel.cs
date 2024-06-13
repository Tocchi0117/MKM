using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Panel : MonoBehaviour
{
    public GameObject panel,prism;
    public Material mat1, mat2;

    public static bool eventFlag,stanby;

    float cnt = 0, priposi_y;

    // Start is called before the first frame update
    void Start()
    {
        prism.SetActive(false);
        priposi_y = prism.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!eventFlag)
        {
            panel.GetComponent<MeshRenderer>().material = mat1;
        }
        else
        {
            panel.GetComponent<MeshRenderer>().material = mat2;
        }

        if(stanby)
        {
            prismMove();
        }
    }

    public static void PanelSousa()
    {
        if (eventFlag)
        {
            eventFlag = false;
        }
        else
        {
            eventFlag = true;
        }
    }

    void prismMove()
    {
        prism.transform.position = new Vector3(prism.transform.position.x, priposi_y + Mathf.Sin(Time.time * 2) * 0.1f, prism.transform.position.z);
        prism.transform.rotation = Quaternion.Euler(180, cnt += 2.5f, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            prism.SetActive(true);

            stanby= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            prism.SetActive(false);

            stanby = false;
        }
    }
}
