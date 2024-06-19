using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveR : MonoBehaviour
{
    Vector3 R;

    [Header("ゴール地点")]
    public Vector3 RG;

    [Header("回転速度")]
    public Vector3 V;

    [Header("機能")]
    public bool Loop;

    float Rx, Ry, Rz;

    // Start is called before the first frame update
    void Start()
    {
        R.x = transform.localEulerAngles.x;
        R.y = transform.localEulerAngles.y;
        R.z = transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        Rx = kaiten(transform.localEulerAngles.x, RG.x, V.x, R.x);
        Ry = kaiten(transform.localEulerAngles.y, RG.y, V.y, R.y);
        Rz = kaiten(transform.localEulerAngles.z, RG.z, V.z, R.z);
        transform.localEulerAngles = new Vector3(Rx, Ry, Rz);
    }

    float kaiten(float R_k,float RG_k,float V_k,float Re)
    {
        if (R_k < RG_k)
        {
            R_k += V_k * Time.deltaTime;
        }
        else
        {
            if (Loop)
            {
                R_k = Re;
            }
        }
        
        return R_k;
    }
}
