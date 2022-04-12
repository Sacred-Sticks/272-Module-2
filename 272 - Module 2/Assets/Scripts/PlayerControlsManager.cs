using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlsManager : MonoBehaviour
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
    [Space]
    [Header("Send Inputs to:")]
    [SerializeField] private GameObject player;

    private InputAction moveAction;
    private InputAction climbAction;
    private InputAction crouchAction;
    private InputAction waitAction;

    private PlayerAnimator animationController;
    private PlayerMove movementController;

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

    private void Start()
    {
        animationController = player.GetComponent<PlayerAnimator>();
        movementController = player.GetComponent<PlayerMove>();
    }

    private void OnMoveUpdate(InputAction.CallbackContext context)
    {
        float movement = context.ReadValue<float>();
        animationController.SetMovement(movement);
        movementController.SetMovement(movement);
        Debug.Log("Updated Movement");
    }

    private void OnClimbUpdate(InputAction.CallbackContext context)
    {
        float climbing = context.ReadValue<float>();
        bool isClimbing = false;
        if (climbing == 1) isClimbing = true;
        animationController.SetClimbing(isClimbing);
        Debug.Log("Updated Climbing");
    }

    private void OnCrouchUpdate(InputAction.CallbackContext context)
    {
        float crouching = context.ReadValue<float>();
        bool isCrouching = false;
        if (crouching == 1) isCrouching = true;
        animationController.SetCrouching(isCrouching);
        Debug.Log("Updated Crouching");
    }

    private void OnWaitUpdate(InputAction.CallbackContext context)
    {
        float waiting = context.ReadValue<float>();
    }
}
