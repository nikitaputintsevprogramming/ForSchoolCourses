using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Horizontal;
    [SerializeField] private float Vertical;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private bool isJumpPressed;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isJumpPressed = Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        if (isJumpPressed)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Vector3 playerPos = new Vector3(Horizontal, 0, Vertical) * speed * Time.deltaTime;
        rb.velocity = playerPos;
    }
}
