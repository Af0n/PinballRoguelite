using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Launcher : MonoBehaviour
{
    public Rigidbody BallRB;
    public float MaxLaunchForce;
    public float ChargeRate;

    

    private Coroutine _chargeCoroutine;
    private float _launchForce;
    private bool _isCharging;

    public bool IsCharging
    {
        get { return _isCharging; }
    }

    public void StartCharge(InputAction.CallbackContext context)
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
            Debug.Log(_launchForce);
            // wait until next frame
            yield return 0;
        }
    }

    public void Launch(InputAction.CallbackContext context)
    {
        // do nothing if not charging
        if (!_isCharging)
        {
            return;
        }

        StopCoroutine(_chargeCoroutine);

        BallRB.AddForce(transform.forward * _launchForce);
    }
}