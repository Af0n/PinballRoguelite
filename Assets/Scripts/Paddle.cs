using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Paddle : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
}
