using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharaCon : MonoBehaviour
{
    public GameObject maincamera;
    public Animator anim;
    public float IdouSpeed, RotateSpeed;

    float cy,Vr=100;

    //ÉRÉìÉgÉçÅ[ÉâÇÃéÊìæ
    float LaxisH = 0.0f;
    float LaxisV = 0.0f;
    float RaxisH = 0.0f;
    float RaxisV = 0.0f;
    float DpadH = 0.0f;
    float DpadV = 0.0f;
    float LRTrigger = 0.0f;


    bool flag;
    Renderer renderComponent1;
    Renderer renderComponent2;
    Renderer renderComponent3;

    float py, tmp;


    // Start is called before the first frame update
    void Start()
    {
        renderComponent1 = transform.Find("Body").gameObject.GetComponent<Renderer>();
        renderComponent2 = transform.Find("Face").gameObject.GetComponent<Renderer>();
        renderComponent3 = transform.Find("Hair").gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            Contoroller_input();

            IDOU();
            KaiTen();

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                anim.SetFloat("Speed", 1);
            }
            else
            {
                anim.SetFloat("Speed", max(LaxisH, LaxisV));
            }
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        /*
        if (other.gameObject.tag != "ground")
        {
            StartCoroutine(Blink());
        }*/

        if (other.gameObject.tag == "Respawn") 
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }







    void Contoroller_input()
    {
        LaxisH = Input.GetAxisRaw("LStickH");
        LaxisV = Input.GetAxisRaw("LStickV");
        RaxisH = Input.GetAxisRaw("RStickH");
        RaxisV = Input.GetAxisRaw("RStickV");
        DpadH = Input.GetAxisRaw("DPadH");
        DpadV = Input.GetAxisRaw("DPadV");
        LRTrigger = Input.GetAxisRaw("LRTrigger");
    }

    void IDOU()
    {
        if (LaxisV != 0 || LaxisH != 0)
        {
            //anim.SetBool("Walk bool", true);
            transform.Translate(Vector3.forward * Time.deltaTime * IdouSpeed * max(LaxisH, LaxisV));

            if (LRTrigger > 0 || Input.GetKey(KeyCode.LeftShift))
            {
                anim.Play("ëñÇË");
                transform.Translate(Vector3.forward * Time.deltaTime * IdouSpeed * max(LaxisH, LaxisV) * 2);
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("íºóß") || anim.GetCurrentAnimatorStateInfo(0).IsName("ëñÇË"))
            {
                anim.Play("ï‡Ç´");
            }
        }/*
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            //anim.SetBool("Walk bool", true);
            transform.Translate(Vector3.forward * Time.deltaTime * IdouSpeed);

            if (Input.GetKey("joystick button 5") || Input.GetKey(KeyCode.LeftShift))
            {
                anim.Play("ëñÇË");
                transform.Translate(Vector3.forward * Time.deltaTime * IdouSpeed * 2);
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("íºóß"))
            {
                anim.Play("ï‡Ç´");
            }
        }*/
        else
        {
            //anim.SetBool("Walk bool", false);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("ï‡Ç´") || anim.GetCurrentAnimatorStateInfo(0).IsName("ëñÇË"))
            {
                anim.Play("íºóß");
            }
        }

        maincamera.transform.position = transform.position;
    }

    void KaiTen()
    {
        py = Mathf.Atan2(LaxisH, LaxisV) * Mathf.Rad2Deg + maincamera.transform.localEulerAngles.y;

        if (LaxisV != 0 || LaxisH != 0)
        {
            tmp = py;
        }
        else
        {
            py = tmp;
        }

        transform.rotation = Quaternion.Euler(0, py, 0);


         cy += Time.deltaTime * RaxisH * Vr;

        /*
        if (Input.GetKeyDown("joystick button 4") && Input.GetKeyDown("joystick button 5")){
            cy = transform.localEulerAngles.y;
        }*/

        maincamera.transform.rotation = Quaternion.Euler(0, cy, 0);




        /*
        if (Input.GetKey(KeyCode.D))
        {
            transform.forward = Vector3.Slerp(transform.forward, maincamera.transform.right, Time.deltaTime * RotateSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.forward = Vector3.Slerp(transform.forward, -maincamera.transform.right, Time.deltaTime * RotateSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.forward = Vector3.Slerp(transform.forward, maincamera.transform.forward, Time.deltaTime * RotateSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.forward = Vector3.Slerp(transform.forward, -maincamera.transform.forward, Time.deltaTime * RotateSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            cy += Time.deltaTime * Vr;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            cy -= Time.deltaTime * Vr;
        }
        */
    }

    float max(float a, float b)
    {
        return Mathf.Sqrt(a * a + b * b);
    }


    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Fire")
        {
            StartCoroutine("Blink");
        }
    }



    IEnumerator Blink()
    {
        if (!flag)
        {
            for (int i = 0; i < 5; i++)
            {
                flag = true;
                renderComponent1.enabled = !renderComponent1.enabled;
                renderComponent2.enabled = !renderComponent2.enabled;
                renderComponent3.enabled = !renderComponent3.enabled;
                yield return new WaitForSeconds(0.1f);
                renderComponent1.enabled = !renderComponent1.enabled;
                renderComponent2.enabled = !renderComponent2.enabled;
                renderComponent3.enabled = !renderComponent3.enabled;
                yield return new WaitForSeconds(0.1f);
            }
            flag = false;
        }
    }
}
