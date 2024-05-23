using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public bool controller_debug;
    public bool invisible_debug;

    [SerializeField] Renderer target;

    //コントローラの取得
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
                Debug.Log("こっち見んな");
            }
            else
            {
                Debug.Log("こっち見ろ");
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

        Debug.Log("左コントローラー：" + LaxisH + "　" + LaxisV);
        Debug.Log("右コントローラー：" + RaxisH + "　" + RaxisV);
        Debug.Log("Dパッド：" + DpadH + "　" + DpadV);
        Debug.Log("トリガー：" + LRTrigger);
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
