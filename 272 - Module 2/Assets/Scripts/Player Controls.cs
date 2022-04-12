using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [Header("Input System")]
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private string actionMapStr;
    [Space]
    [Header("Input Field Names")]
    [SerializeField] private string moveStr;
    [SerializeField] private string climbStr;
    [SerializeField] private string crouchStr;
    [SerializeField] private string waitStr;

    private InputAction moveAction;
    private InputAction climbAction;
    private InputAction crouchAction;
    private InputAction waitAction;

    private void Awake()
    {
        var actionMap = playerControls.FindActionMap(actionMapStr);

        moveAction = actionMap.FindAction(moveStr);
        moveAction.performed += OnMoveUpdate;
        moveAction.canceled += OnMoveUpdate;
        moveAction.Enable();

        climbAction = actionMap.FindAction(climbStr);
        climbAction.performed += OnClimbUpdate;
        climbAction.canceled += OnClimbUpdate;
        climbAction.Enable();

        crouchAction = actionMap.FindAction(crouchStr);
        crouchAction.performed += OnCrouchUpdate;
        crouchAction.canceled += OnCrouchUpdate;
        crouchAction.Enable();

        waitAction = actionMap.FindAction(waitStr);
        waitAction.performed += OnWaitUpdate;
        waitAction.canceled += OnWaitUpdate;
        waitAction.Enable();
    }

    private void OnMoveUpdate(InputAction.CallbackContext context)
    {
        
    }

    private void OnClimbUpdate(InputAction.CallbackContext context)
    {

    }

    private void OnCrouchUpdate(InputAction.CallbackContext context)
    {

    }

    private void OnWaitUpdate(InputAction.CallbackContext context)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
