using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ConstantForce))]

public class Paddle : MonoBehaviour
{
    public float PaddleForce;

    private ConstantForce _cf;
    private bool _isFlipped;

    public bool IsFlipped
    {
        get { return _isFlipped; }
    }

    private void Awake()
    {
        _cf = GetComponent<ConstantForce>();
    }

    public void Flip(InputAction.CallbackContext context)
    {
        _isFlipped = true;
        _cf.relativeForce = new(0f, 0f, PaddleForce);
    }

    public void Unflip(InputAction.CallbackContext context)
    {
        _isFlipped = false;
        _cf.relativeForce = new(0f, 0f, PaddleForce);
    }
}
