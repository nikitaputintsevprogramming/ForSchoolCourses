using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicMotion : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _gravitySpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Vector3.down * _gravitySpeed, ForceMode.Force);
    }
}
