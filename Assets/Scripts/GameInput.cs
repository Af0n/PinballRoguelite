using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Launcher))]

public class GameInput : MonoBehaviour
{
    private InputSystem_Actions _actions;
    private InputAction _launcherAction;
    private InputAction _leftPaddleAction;

    private Launcher _launchScrpit;
    public Paddle LeftPaddleScript;

    private void Awake()
    {
        // field populating
        _launchScrpit = GetComponent<Launcher>();

        // Input System Boilerplate
        _actions = new();

        _launcherAction = _actions.Pinball.Launcher;
        _leftPaddleAction = _actions.Pinball.LeftPaddle;
    }

    private void OnEnable()
    {
        _launcherAction.Enable();
        _launcherAction.performed += _launchScrpit.StartCharge;
        _launcherAction.canceled += _launchScrpit.Launch;

        _leftPaddleAction.Enable();
        _leftPaddleAction.performed += LeftPaddleScript.Flip;
        _leftPaddleAction.canceled += LeftPaddleScript.Unflip;
    }
    
    private void OnDisable() {
        _launcherAction.Disable();
        _leftPaddleAction.Disable();
    }
}
