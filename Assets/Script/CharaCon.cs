using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CharaCon : MonoBehaviour
{
    public GameObject maincamera;
    public float IdouSpeed, RotateSpeed;

    float py, cy, Vr = 100, tmp;

    //�R���g���[���̎擾
    float LStickX = 0.0f;
    float LStickY = 0.0f;
    float RStickX = 0.0f;

    public static bool push;
    bool flag;

    Renderer renderComponent1;
    Renderer renderComponent2;
    Renderer renderComponent3;

    Animator anim;
    Rigidbody rb;



    [HideInInspector]public GameObject tmpPanel;

    // Start is called before the first frame update
    void Start()
    {
        renderComponent1 = transform.Find("Body").gameObject.GetComponent<Renderer>();
        renderComponent2 = transform.Find("Face").gameObject.GetComponent<Renderer>();
        renderComponent3 = transform.Find("Hair").gameObject.GetComponent<Renderer>();

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            Contoroller_input();

            //�u�{�^���v���[�V�������ȊO
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("�{�^��"))
            {
                IDOU();
                KaiTen();
            }
            CameraKaiTen();

            anim.SetFloat("Speed", max(LStickX, LStickY));

            if(EventPanel.stanby && ControllerManager.PushTrigger)
            {
                anim.Play("�{�^��");
                rb.velocity = Vector3.zero;
            }
        }
    }




    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Respawn") 
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EventPanel")
        {
            tmpPanel = other.GameObject();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EventPanel")
        {
            tmpPanel = null;
        }
    }





    void Contoroller_input()
    {
        LStickX = ControllerManager.LStickX;
        LStickY = ControllerManager.LStickY;
        RStickX = ControllerManager.RStickX;
    }

    public void IDOU()
    {
        if (LStickX != 0 || LStickY != 0)
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * IdouSpeed * max(LStickX, LStickY));

            // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
            Vector3 cameraForward = Vector3.Scale(maincamera.transform.forward, new Vector3(1, 0, 1)).normalized;

            // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
            Vector3 moveForward = cameraForward * LStickY + maincamera.transform.right * LStickX;

            // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
            rb.velocity = moveForward * IdouSpeed + new Vector3(0, rb.velocity.y, 0);


            if (ControllerManager.DashTrigger)
            {
                anim.Play("����");
                rb.velocity = moveForward * IdouSpeed * 3 + new Vector3(0, rb.velocity.y, 0);
            }
            else if (!anim.GetCurrentAnimatorStateInfo(0).IsName("����"))
            {
                anim.Play("����");
            }
        }
        else
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("����"))
            {
                anim.Play("����");
                rb.velocity = Vector3.zero;
            }
        }

        maincamera.transform.position = transform.position;
    }

    void KaiTen()
    {
        py = Mathf.Atan2(LStickX, LStickY) * Mathf.Rad2Deg + maincamera.transform.localEulerAngles.y;

        if (LStickX != 0 || LStickY != 0)
        {
            tmp = py;
        }
        else
        {
            py = tmp;
        }

        transform.rotation = Quaternion.Euler(0, py, 0);
    }

    void CameraKaiTen()
    {
        cy += Time.deltaTime * RStickX * Vr;

        maincamera.transform.rotation = Quaternion.Euler(0, cy, 0);
    }

    float max(float a, float b)
    {
        return Mathf.Sqrt(a * a + b * b);
    }




    //�A�j���[�V�����̎w�肵���^�C�~���O����Q�Ƃ���
    void buttonPush()
    {
        push=true;
        Debug.Log("�Ăяo������");
        tmpPanel.GetComponent<EventPanel>().PanelSousa();
        Sound_SE.playsound(0, 4);
    }




    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Fire")
        {
            StartCoroutine(Blink());
        }
    }




    IEnumerator Blink()
    {
        if (!flag)
        {
            flag = true;
            for (int i = 0; i < 5; i++)
            {
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
