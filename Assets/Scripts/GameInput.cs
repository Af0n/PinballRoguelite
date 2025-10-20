using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Launcher))]

public class GameInput : MonoBehaviour
{
    private InputSystem_Actions _actions;
    private InputAction _launcherAction;

    private Launcher _launchScrpit;

    private void Awake()
    {
        // field populating
        _launchScrpit = GetComponent<Launcher>();

        // Input System Boilerplate
        _actions = new();

        _launcherAction = _actions.Pinball.Launcher;
    }

    private void OnEnable()
    {
        _launcherAction.Enable();
        _launcherAction.performed += _launchScrpit.StartCharge;
        _launcherAction.canceled += _launchScrpit.Launch;
    }
    
    private void OnDisable() {
        _launcherAction.Disable();
    }
}
