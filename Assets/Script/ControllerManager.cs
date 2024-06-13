using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour
{
    //InputActionのクラス型の変数を宣言
    ControllerActions controllerActions;

    public static float LStickX, LStickY, RStickX, RStickY;

    public static bool DashTrigger, MenuTrigger, PushTrigger, CancelTrigger;

    void Awake()
    {
        //InputActionのクラス型のインスタンスを生成
        //Awake内で行わないとエラー、もしくは値の取得ができない
        controllerActions = new ControllerActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerActions();
        UIActions();
    }

    void PlayerActions()
    {
        //InputActionのPlayerのWalkからVecter2の値を取得
        LStickX = controllerActions.Player.Walk.ReadValue<Vector2>().x;
        LStickY = controllerActions.Player.Walk.ReadValue<Vector2>().y;

        //InputActionのPlayerのCameraからVecter2の値を取得
        RStickX = controllerActions.Player.Camera.ReadValue<Vector2>().x;
        RStickY = controllerActions.Player.Camera.ReadValue<Vector2>().y;

        //Dashボタンが押されたとき
        if (controllerActions.Player.Dash.WasPressedThisFrame())
        {
            DashTrigger = true;
        }
        //Dashボタンが離されたとき
        else if (controllerActions.Player.Dash.WasReleasedThisFrame())
        {
            DashTrigger = false;
        }

        //Menuボタンが押された瞬間
        if (controllerActions.Player.Menu.triggered)
        {
            MenuTrigger = true;
        }
        else
        {
            MenuTrigger = false;
        }

        //Pushボタンが押された瞬間
        if (controllerActions.Player.Push.triggered)
        {
            PushTrigger = true;
        }
        else
        {
            PushTrigger = false;
        }
    }


    void UIActions()
    {
        //Cancelボタンが押された瞬間
        if (controllerActions.UI.Cancel.triggered)
        {
            CancelTrigger = true;
        }
        else
        {
            CancelTrigger = false;
        }
    }








    //InputActionを使用する上で必須の３種、有効化と無効化、これがないとエラー、もしくは値の取得ができない///
    private void OnEnable()
    {
        if(controllerActions != null)
        {
            controllerActions.Enable();
        }
    }

    private void OnDisable()
    {
        if(controllerActions != null)
        {
            controllerActions.Disable();
        }
    }

    private void OnDestroy()
    {
        if (controllerActions != null)
        {
            controllerActions.Dispose();
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////
}
