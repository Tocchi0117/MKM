using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour
{
    //InputAction�̃N���X�^�̕ϐ���錾
    ControllerActions controllerActions;

    public static float LStickX, LStickY, RStickX, RStickY;

    public static bool DashTrigger, MenuTrigger, PushTrigger, CancelTrigger;

    void Awake()
    {
        //InputAction�̃N���X�^�̃C���X�^���X�𐶐�
        //Awake���ōs��Ȃ��ƃG���[�A�������͒l�̎擾���ł��Ȃ�
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
        //InputAction��Player��Walk����Vecter2�̒l���擾
        LStickX = controllerActions.Player.Walk.ReadValue<Vector2>().x;
        LStickY = controllerActions.Player.Walk.ReadValue<Vector2>().y;

        //InputAction��Player��Camera����Vecter2�̒l���擾
        RStickX = controllerActions.Player.Camera.ReadValue<Vector2>().x;
        RStickY = controllerActions.Player.Camera.ReadValue<Vector2>().y;

        //Dash�{�^���������ꂽ�Ƃ�
        if (controllerActions.Player.Dash.WasPressedThisFrame())
        {
            DashTrigger = true;
        }
        //Dash�{�^���������ꂽ�Ƃ�
        else if (controllerActions.Player.Dash.WasReleasedThisFrame())
        {
            DashTrigger = false;
        }

        //Menu�{�^���������ꂽ�u��
        if (controllerActions.Player.Menu.triggered)
        {
            MenuTrigger = true;
        }
        else
        {
            MenuTrigger = false;
        }

        //Push�{�^���������ꂽ�u��
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
        //Cancel�{�^���������ꂽ�u��
        if (controllerActions.UI.Cancel.triggered)
        {
            CancelTrigger = true;
        }
        else
        {
            CancelTrigger = false;
        }
    }








    //InputAction���g�p�����ŕK�{�̂R��A�L�����Ɩ������A���ꂪ�Ȃ��ƃG���[�A�������͒l�̎擾���ł��Ȃ�///
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
