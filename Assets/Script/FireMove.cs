using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    public float V, dtime;
    float tmp;

    public static bool flag;
    bool f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tmp = V;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag)
        {
            StartCoroutine("restart");
        }
        else
        {
            if (!Sound_SE.audioSource[1].isPlaying)
            {
                Sound_SE.playsound(1, 1);
            }


            if (Fire.flag)
            {
                StartCoroutine("restart");
            }
            else
            {
                V= tmp;
                rb.velocity = Vector3.forward * V;
            }
        }
    }

    private IEnumerator restart()
    {
        if (!f)
        {
            f = true;

            V = 0;
            rb.velocity = Vector3.zero;

            if (!flag)
            {
                yield return new WaitForSeconds(dtime);
                flag = true;
            }
            yield return new WaitForSeconds(dtime);
            V = tmp;
            Fire.flag = false;

            f = false;
        }
    }
}
