using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    public float V, dtime;

    public static bool flag;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
                //transform.Translate(Vector3.forward * Time.deltaTime * V);
                rb.velocity = Vector3.forward * V;
            }
        }
    }

    private IEnumerator restart()
    {
        var v = V;
        V = 0;
        rb.velocity = Vector3.zero;

        if (!flag)
        {
            yield return new WaitForSeconds(dtime);
            flag = true;
        }
        yield return new WaitForSeconds(dtime);
        V = v;
        Fire.flag = false;
        StopCoroutine("restart");
    }
}
