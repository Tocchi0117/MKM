using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public bool controller_debug;
    public bool invisible_debug;

    [SerializeField] Renderer target;

    //�R���g���[���̎擾
    float LaxisH = 0.0f;
    float LaxisV = 0.0f;
    float RaxisH = 0.0f;
    float RaxisV = 0.0f;
    float DpadH = 0.0f;
    float DpadV = 0.0f;
    float LRTrigger = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller_debug)
        {
            Contoroller_input_Debug();
        }

        if(invisible_debug)
        {
            if (target.isVisible)
            {
                Debug.Log("�����������");
            }
            else
            {
                Debug.Log("����������");
            }
        }
    }


    void Contoroller_input_Debug()
    {
        LaxisH = Input.GetAxisRaw("LStickH");
        LaxisV = Input.GetAxisRaw("LStickV");
        RaxisH = Input.GetAxisRaw("RStickH");
        RaxisV = Input.GetAxisRaw("RStickV");
        DpadH = Input.GetAxisRaw("DPadH");
        DpadV = Input.GetAxisRaw("DPadV");
        LRTrigger = Input.GetAxisRaw("LRTrigger");

        Debug.Log("���R���g���[���[�F" + LaxisH + "�@" + LaxisV);
        Debug.Log("�E�R���g���[���[�F" + RaxisH + "�@" + RaxisV);
        Debug.Log("D�p�b�h�F" + DpadH + "�@" + DpadV);
        Debug.Log("�g���K�[�F" + LRTrigger);
    }

    
    /*
    private void OnBecameVisible()
    {
        //target_bool = true;
    }
    private void OnBecameInvisible()
    {
        //target_bool = false;
    }*/

}
