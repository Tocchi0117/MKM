using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text Rtxt;
    float time;
    int cnt, rank;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            time=Gate.time;
            cnt = Answer_maru.cnt + Answer_batu.cnt;

            Rtxt.text = $"�N���A���ԁF{time}\r\n���𐔁F{cnt}\r\n�X�R�A\r\n�]��";
        }
    }
}
