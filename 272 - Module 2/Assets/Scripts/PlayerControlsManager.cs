using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControlsManager : MonoBehaviour
{
    [Header("Input System")]
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private string actionMapStr;
    [Space]
    [Header("Input Field Names")]
    [SerializeField] private string moveStr;
    [SerializeField] private string climbStr;
    [SerializeField] private string restartStr;
    [SerializeField] private string waitStr;
    [SerializeField] private string pauseStr;
    [Space]
    [Header("Send Inputs to:")]
    [SerializeField] private GameObject player;

    private InputAction moveAction;
    private InputAction climbAction;
    private InputAction restartAction;
    private InputAction waitAction;
    private InputAction pauseAction;

    private PlayerAnimator animationController;
    private PlayerMove movementController;
    private OpenMenu openMenu;
    private LivesManager livesManager;

    private void Awake()
    {
        var actionMap = playerControls.FindActionMap(actionMapStr);

        moveAction = actionMap.FindAction(moveStr);
        moveAction.performed += OnMoveUpdate;
        moveAction.canceled += OnMoveUpdate;
        moveAction.Enable();

        climbAction = actionMap.FindAction(climbStr);
        climbAction.performed += OnClimbUpdate;
        //climbAction.canceled += OnClimbUpdate;
        climbAction.Enable();

        restartAction = actionMap.FindAction(restartStr);
        restartAction.performed += OnRestartUpdate;
        restartAction.canceled += OnRestartUpdate;
        restartAction.Enable();

        waitAction = actionMap.FindAction(waitStr);
        waitAction.performed += OnWaitUpdate;
        waitAction.canceled += OnWaitUpdate;
        waitAction.Enable();

        pauseAction = actionMap.FindAction(pauseStr);
        pauseAction.performed += OnPauseUpdate;
        pauseAction.Enable();
    }

    private void Start()
    {
        animationController = player.GetComponent<PlayerAnimator>();
        movementController = player.GetComponent<PlayerMove>();
        openMenu = GetComponent<OpenMenu>();
        livesManager = GetComponent<LivesManager>();
    }

    private void OnMoveUpdate(InputAction.CallbackContext context)
    {
        float movement = context.ReadValue<float>();
        animationController.SetMovement(movement);
        movementController.SetMovement(movement);
        //Debug.Log("Updated Movement");
    }

    private void OnClimbUpdate(InputAction.CallbackContext context)
    {
        float climbing = context.ReadValue<float>();
        bool isClimbing = false;
        if (climbing == 1) isClimbing = true;
        animationController.SetClimbing(isClimbing);
        //Debug.Log("Updated Climbing");
    }

    private void OnRestartUpdate(InputAction.CallbackContext context)
    {
        float restart = context.ReadValue<float>();
        if (restart == 1) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Debug.Log("Updated Crouching");
    }

    private void OnWaitUpdate(InputAction.CallbackContext context)
    {
        float waiting = context.ReadValue<float>();
        if (waiting == 1) livesManager.ResetTimer();
    }

    private void OnPauseUpdate(InputAction.CallbackContext context)
    {
        openMenu.OpenPauseMenu();
    }
}
