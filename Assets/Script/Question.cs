using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    public GameObject[] Q;
    public GameObject[] A;
    public Text test;
    public TextAsset QA;
    public float time;
    public int question;

    List<string[]>Qtxt=new List<string[]>();

    bool flag;

    // Start is called before the first frame update
    void Start()
    {
        StringReader reader = new StringReader(QA.text);
        while (reader.Peek() != -1)
        {
            Qtxt.Add(reader.ReadLine().Split(","));
        }

        for (int i = 0; i < Q.Length; i++)
        {
            Q[i].SetActive(false);
        }

        Debug.Log(Qtxt.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < Q.Length; i++)
            {
                Q[i].SetActive(true);
            }
            StartCoroutine(textVisible(Qtxt[question][0]));

            if (Qtxt[question][1]== "›")
            {
                A[0].GetComponent<Answer_maru>().correct=true;

            }
            else
            {
                A[1].GetComponent<Answer_batu>().correct = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < Q.Length; i++)
            {
                Q[i].SetActive(false);
            }
        }
    }

    IEnumerator textVisible(string text)
    {
        if (!flag)
        {
            flag = true;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == @"\")
                {
                    test.text += "\r\n";
                }
                else
                {
                    test.text += text[i].ToString();
                }


                yield return new WaitForSeconds(time);
            }
        }
    }
}
