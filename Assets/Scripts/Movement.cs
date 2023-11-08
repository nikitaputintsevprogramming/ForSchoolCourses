using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpForce;

    private bool isJumped;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        isJumped = false;
    }

    private void Update()
    {
        isJumped = Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        if(isJumped)
        {
            _rigidbody.AddForce(transform.up * _jumpForce * Time.deltaTime, ForceMode.Impulse);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            _rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime));

            if (targetRotation == transform.rotation )
            {
                _rigidbody.MovePosition(transform.position + moveDirection * _speed * Time.fixedDeltaTime);
            }
        }
    }
}
