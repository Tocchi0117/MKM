using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP : MonoBehaviour
{
    [Header("移動速度")]
    public Vector3 _velocity;
    Vector3 tmp_v;

    [Header("移動距離")]
    public Vector3 end;

    Vector3 strat;

    [Header("移動方向")]
    public bool x;
    public bool y;
    public bool z;

    [Header("ループ")]
    public bool LoopFlag_x;
    public bool LoopFlag_y;
    public bool LoopFlag_z;

    [Header("往復")]
    public bool OhukuFlag_x;
    public bool OhukuFlag_y;
    public bool OhukuFlag_z;

    bool Ohuku;

    float Posi_x, Posi_y, Posi_z;


    // Start is called before the first frame update
    void Start()
    {
        //初期値設定
        strat = transform.position;
        Posi_x = strat.x;
        Posi_y = strat.y;
        Posi_z = strat.z;
    }

    // Update is called once per frame
    void Update()
    {
        // 速度_velocityで移動する
        if (x)
        {
            Posi_x = MovePosition(transform.position.x, strat.x, end.x, _velocity.x);
        }
        if (y)
        {
            Posi_y = MovePosition(transform.position.y, strat.y, end.y, _velocity.y);
        }
        if (z)
        {
            Posi_z = MovePosition(transform.position.z, strat.z, end.z, _velocity.z);
        }


        //繰り返し
        if (LoopFlag_x)
        {
            Posi_x = LoopPosition(transform.position.x, strat.x, end.x, _velocity.x);
        }
        if (LoopFlag_y)
        {
            Posi_y = LoopPosition(transform.position.y, strat.y, end.y, _velocity.y);
        }
        if (LoopFlag_z)
        {
            Posi_z = LoopPosition(transform.position.z, strat.z, end.z, _velocity.z);
        }


        //往復
        if (OhukuFlag_x)
        {
            Posi_x = OhukuPosition(transform.position.x, strat.x, end.x, _velocity.x);
        }
        if (OhukuFlag_y)
        {
            Posi_y = OhukuPosition(transform.position.y, strat.y, end.y, _velocity.y);
        }
        if (OhukuFlag_z)
        {
            Posi_z = OhukuPosition(transform.position.z, strat.z, end.z, _velocity.z);
        }


        transform.position = new Vector3(Posi_x, Posi_y, Posi_z);
    }

    float OhukuPosition(float P, float Ps, float Pe, float V)
    {
        if (Ohuku)
        {
            P += V * Time.deltaTime;
            if (P > Ps + Pe)
            {
                Ohuku = false;
            }
        }
        else
        {
            P += V * Time.deltaTime * -1;
            if (P < Ps)
            {
                Ohuku = true;
            }
        }
        return P;
    }

    float LoopPosition(float P, float Ps, float Pe, float V)
    {
        if (P < Ps + Pe)
        {
            P += V * Time.deltaTime;
        }
        else
        {
            P = Ps;
        }
        return P;
    }

    float MovePosition(float P, float Ps, float Pe, float V)
    {
        if (P < Ps + Pe)
        {
            P += V * Time.deltaTime;
        }
        return P;
    }
}
