using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveP : MonoBehaviour
{
    [Header("à⁄ìÆë¨ìx")]
    public Vector3 velocity;

    [Header("à⁄ìÆãóó£")]
    public Vector3 distance;

    [Header("à⁄ìÆï˚ñ@")]
    [Header("í èÌ")]
    public bool nomalX;
    public bool nomalY;
    public bool nomalZ;
    [Header("åJï‘")]
    public bool loopX;
    public bool loopY;
    public bool loopZ;
    Vector3 Fpos;
    [Header("âùïú")]
    public bool roundX;
    public bool roundY;
    public bool roundZ;
    Vector3 Reverse;
    bool X, Y, Z;

    float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        Fpos = transform.localPosition;
        Reverse = transform.localPosition - distance;
        distance += transform.localPosition;
}

    // Update is called once per frame
    void Update()
    {
        speed = Time.deltaTime;

        HowToMove();

        nomalMove();
        loopMove();
        roundMove();
    }

    void nomalMove()
    {
        if (nomalX)
        {
            if (judge(distance.x, transform.localPosition.x, Fpos.x))
            {
                transform.Translate(Vector3.right * speed * velocity.x);
            }
        }
        if (nomalY)
        {
            if (judge(distance.y, transform.localPosition.y, Fpos.y))
            {
                transform.Translate(Vector3.up * speed * velocity.y);
            }
        }
        if (nomalZ)
        {
            if (judge(distance.z, transform.localPosition.z, Fpos.z))
            {
                transform.Translate(Vector3.forward * speed * velocity.z);
            }
        }
    }

    void loopMove()
    {
        if (loopX)
        {
            if (judge(distance.x, transform.localPosition.x, Fpos.x))
            {
                transform.Translate(Vector3.right * speed * velocity.x);
            }
            else
            {
                transform.localPosition = new Vector3(Fpos.x, transform.localPosition.y, transform.localPosition.z);
            }
        }
        if (loopY)
        {
            if (judge(distance.y, transform.localPosition.y, Fpos.y))
            {
                transform.Translate(Vector3.up * speed * velocity.y);
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, Fpos.y, transform.localPosition.z);
            }
        }
        if (loopZ)
        {
            if (judge(distance.z, transform.localPosition.z, Fpos.z))
            {
                transform.Translate(Vector3.forward * speed * velocity.z);
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Fpos.z);
                Debug.Log("Ç±Ç±ÅH");
            }
        }
    }

    void roundMove()
    {
        if (roundX)
        {
            if (!X && judge(distance.x, transform.localPosition.x, Fpos.x))
            {
                transform.Translate(Vector3.right * speed * velocity.x);
            }
            else
            {
                X = true;
            }

            if (X && judge(Reverse.x, transform.localPosition.x, Fpos.x))
            {
                transform.Translate(Vector3.right * speed * -velocity.x);
            }
            else
            {
                X = false;
            }
        }
        if (roundY)
        {
            if (!Y && judge(distance.y, transform.localPosition.y, Fpos.y))
            {
                transform.Translate(Vector3.up * speed * velocity.y);
            }
            else
            {
                Y = true;
            }

            if (Y && judge(Reverse.y, transform.localPosition.y, Fpos.y))
            {
                transform.Translate(Vector3.up * speed * -velocity.y);
            }
            else
            {
                Y = false;
            }
        }
        if (roundZ)
        {
            if (!Z && judge(distance.z, transform.localPosition.z, Fpos.z))
            {
                transform.Translate(Vector3.forward * speed * velocity.z);
            }
            else
            {
                Z = true;
            }

            if (Z && judge(Reverse.z, transform.localPosition.z, Fpos.z))
            {
                transform.Translate(Vector3.forward * speed * -velocity.z);
            }
            else
            {
                Z = false;
            }
        }
    }

    bool judge(float dis, float pos, float Fp)
    {
        if (dis - Fp < 0)
        {
            return dis - pos < 0;
        }
        else
        {
            return dis - pos > 0;
        }
    }


    void HowToMove()
    {
        if (nomalX)
        {
            loopX = false;
            roundX = false;
        }
        else if(loopX)
        {
            roundX = false;
        }

        if (nomalY)
        {
            loopY = false;
            roundY = false;
        }
        else if (loopY)
        {
            roundY = false;
        }

        if (nomalZ)
        {
            loopZ = false;
            roundZ = false;
        }
        else if (loopZ)
        {
            roundZ = false;
        }
    }
}
