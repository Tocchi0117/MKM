using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPanel : MonoBehaviour
{
    public GameObject panel,prism;
    public Material mat1, mat2;

    public static bool stanby;

    float cnt = 0, priposi_y;


    [HideInInspector] public bool flag;

    // Start is called before the first frame update
    void Start()
    {
        prism.SetActive(false);
        priposi_y = prism.transform.position.y;
        panel.GetComponent<MeshRenderer>().material = mat1;
    }

    // Update is called once per frame
    void Update()
    {
        if(stanby)
        {
            prismMove();
        }
    }

    public void PanelSousa()
    {
        flag = !flag;

        if(flag)
        {
            panel.GetComponent<MeshRenderer>().material = mat2;
        }
        else
        {
            panel.GetComponent<MeshRenderer>().material = mat1;
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
