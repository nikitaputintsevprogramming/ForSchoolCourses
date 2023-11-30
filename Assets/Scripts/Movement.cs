using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Movement : MonoBehaviour
//{
//    [SerializeField] private float _speed = 5f;
//    [SerializeField] private float _rotationSpeed = 180f;
//    [SerializeField] private float _jumpForce = 10f;

//    private Rigidbody _rigidbody;
//    private bool _isJumped;

//    private Animator anim;

//    private void Start()
//    {
//        _rigidbody = GetComponent<Rigidbody>();
//        _rigidbody.freezeRotation = true;
//        _isJumped = false;

//        anim = GetComponent<Animator>();
//    }

//    private void Update()
//    {
//        _isJumped = Input.GetKeyDown(KeyCode.Space);
//    }

//    private void FixedUpdate()
//    {
//        if (_isJumped)
//            _rigidbody.AddForce(transform.up * _jumpForce * Time.fixedDeltaTime, ForceMode.Force);

//        float horizontalInput = Input.GetAxis("Horizontal");
//        float verticalInput = Input.GetAxis("Vertical");

//        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

//        if(moveDirection != Vector3.zero)
//        {
//            anim.SetBool("state", true);

//            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
//            _rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime));
//            if (transform.rotation == targetRotation)
//                _rigidbody.MovePosition(transform.position + moveDirection * _speed * Time.fixedDeltaTime);
//        }
//        else
//        {
//            anim.SetBool("state", false);
//        }
//    }
//}

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 180f;

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }
}
