using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock_Time : MonoBehaviour
{
    public bool digital, analog;
    public bool ui;

    [Header("デジタル")]
    public GameObject UI;
    public Text yyyyMMdd;
    public Text ddd;
    public Text HHmm;
    public Text ss;

    // Start is called before the first frame update
    void Start()
    {
        if(digital && ui)
        {
            UI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //現在時刻の取得
        var nowTime = DateTime.Now;
        if (digital)
        {
            yyyyMMdd.text = $"{nowTime.ToString("yyyy")}/{nowTime.ToString("MM")}/{nowTime.ToString("dd")}";
            ddd.text = nowTime.ToString("ddd");
            HHmm.text = $"{nowTime.ToString("HH")}:{nowTime.ToString("mm")}";
            ss.text = nowTime.ToString("ss");
        }


        if (Input.GetKeyDown("joystick button 3") && digital && ui){
            UI.SetActive(!UI.activeSelf);
            Debug.Log("通ってる？");
        }
    }
}
