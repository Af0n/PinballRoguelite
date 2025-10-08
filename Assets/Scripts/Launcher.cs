using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Launcher : MonoBehaviour
{
    public Rigidbody BallRB;
    public float MaxLaunchForce;
    public float ChargeRate;

    private InputSystem_Actions _actions;
    private InputAction _launcherAction;

    private Coroutine _chargeCoroutine;
    private float _launchForce;
    private bool _isCharging;

    public bool IsCharging
    {
        get { return _isCharging; }
    }

    private void Awake()
    {
        // Input System Boilerplate
        _actions = new();

        _launcherAction = _actions.Pinball.Launcher;
    }

    private void StartCharge(InputAction.CallbackContext context)
    {
        _chargeCoroutine = StartCoroutine(DoCharge());
    }

    private IEnumerator DoCharge()
    {
        _isCharging = true;
        _launchForce = 0;

        while (true)
        {
            // charge per frame
            _launchForce += ChargeRate * Time.deltaTime;
            // prevent over charging
            _launchForce = Mathf.Min(_launchForce, MaxLaunchForce);
            // wait until next frame
            yield return 0;
        }
    }

    private void Launch(InputAction.CallbackContext context)
    {
        // do nothing if not charging
        if (!_isCharging)
        {
            return;
        }

        StopCoroutine(_chargeCoroutine);

        BallRB.AddForce(transform.forward * _launchForce);
    }

    private void OnEnable()
    {
        _launcherAction.Enable();
        _launcherAction.performed += StartCharge;
        _launcherAction.canceled += Launch;
    }
    
    private void OnDisable() {
        _launcherAction.Disable();
    }
}