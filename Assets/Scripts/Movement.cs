using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _horizontal;
    [SerializeField] private float _vertical;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private bool _isJumpPressed;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _gravityScale;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _isJumpPressed = Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        if (_isJumpPressed)
        {
            _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void PlayerMovement()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        Vector3 playerPos;
        playerPos.x = _horizontal * _speed * Time.deltaTime;
        playerPos.y = 0f;
        playerPos.z = _vertical * _speed * Time.deltaTime;

        gameObject.transform.Translate(0, 0, _vertical);
        gameObject.transform.Rotate(0, _horizontal, 0);
    }
}