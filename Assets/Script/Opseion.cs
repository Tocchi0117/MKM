using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opseion : MonoBehaviour
{
    [Header("表示されるUI")]
    public GameObject[] UI;

    [Header("選択されるボタン")]
    public Button[] SelectButton;

    [Header("矢印")]
    public GameObject Arrow;
    public EventSystem eventsystem;
    GameObject selectedObj;


    private void Start()
    {
        pause_sub();
    }

    private void Update()
    {
        if (ControllerManager.MenuTrigger)
        {
            pause();
        }

        if(ControllerManager.CancelTrigger)
        {
            if (UI[0].activeSelf)
            {
                pause();
            }
            else
            {
                ChangeUI_01();
            }
        }


        try
        {
            selectedObj = eventsystem.currentSelectedGameObject.gameObject;
        }
        catch
        {
            if (UI[0].activeSelf)
            {
                SelectButton[0].Select();
            }
            else
            {
                SelectButton[1].Select();
            }
        }


        Arrow.transform.position = selectedObj.transform.position;
    }

    /// ////////////////////////////////////////////////////////////////
    public void pause()
    {
        bool activeUI = false;

        for (int i = 0; i < UI.Length; i++)
        {
            if (UI[i].activeSelf)
            {
                activeUI = true;
            }
        }

        if (activeUI)
        {
            pause_sub();
        }
        else
        {
            UI[0].SetActive(!UI[0].activeSelf);
            Arrow.SetActive(!Arrow.activeSelf);
            SelectButton[0].Select();
            Time.timeScale = 0;

        }
    }

    void pause_sub()
    {
        for (int i = 0; i < UI.Length; i++)
        {
            UI[i].SetActive(false);
        }
        Arrow.SetActive(false);
        Time.timeScale = 1;
    }
    /// ////////////////////////////////////////////////////////////////

    public void SceneIDOU()
    {
        SceneManager.LoadScene("Title");
    }


    public void ChangeUI_01()
    {
        UI[0].SetActive(!UI[0].activeSelf);
        UI[1].SetActive(!UI[1].activeSelf);
        if (UI[0].activeSelf)
        {
            SelectButton[0].Select();
        }
        else
        {
            SelectButton[1].Select();
        }
    }









    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }
}
