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


    [Header("アナログ")]
    public GameObject tyousin;
    public GameObject tansin;
    public GameObject byousin;


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

        if(analog)
        {
            tansin.transform.localEulerAngles = new Vector3(0, nowTime.Hour * -30, 0);
            tyousin.transform.localEulerAngles = new Vector3(0, nowTime.Minute * -6, 0);
            byousin.transform.localEulerAngles = new Vector3(0, nowTime.Second * -6, 0);
        }

        if (Input.GetKeyDown("joystick button 3") && digital && ui && Time.timeScale != 0)
        {
            UI.SetActive(!UI.activeSelf);
        }
    }
}
