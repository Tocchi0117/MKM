using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveS : MonoBehaviour
{
    [Header("�ő�T�C�Y")]
    public Vector3 S_max = new Vector3(1, 1, 1);

    [Header("�ŏ��T�C�Y")]
    public Vector3 S_min = new Vector3(1, 1, 1);

    [Header("�ύX���x")]
    public Vector3 V;

    [Header("�ύX�ӏ�")]
    public bool x;
    public bool y;
    public bool z;

    [Header("�@�\")]
    public bool Loop;
    public bool Ohuku;

    Vector3 strat;
    float Sx, Sy, Sz;
    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        strat = transform.localScale;
        Sx = transform.localScale.x;
        Sy = transform.localScale.y;
        Sz = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (x)
        {
            Sx = ScaleEdit(transform.localScale.x, Sx, S_max.x, S_min.x, V.x, strat.x);
        }
        if (y)
        {
            Sy = ScaleEdit(transform.localScale.y, Sy, S_max.y, S_min.y, V.y, strat.y);
        }
        if (z)
        {
            Sz = ScaleEdit(transform.localScale.z, Sz, S_max.z, S_min.z, V.z, strat.z);
        }


        transform.localScale = new Vector3(Sx, Sy, Sz);
    }


    float ScaleEdit(float localScale, float Se,float Max,float Min,float Ve,float Origin)
    {
        if (localScale < Max && !flag)
        {
            Se += Ve;
        }
        else
        {
            if (Loop)
            {
                Se = Origin;
            }
            else if (Ohuku)
            {
                if (localScale > Min)
                {
                    Se -= Ve;
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
        }
        return Se;
    }
}
