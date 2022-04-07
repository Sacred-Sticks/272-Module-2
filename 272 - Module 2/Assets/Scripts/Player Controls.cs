using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private string actionMapStr;
    
    private void Awake()
    {
        var actionMap = playerControls.FindActionMap(actionMapStr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
