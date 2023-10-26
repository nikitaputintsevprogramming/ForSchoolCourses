using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 180f;
    [SerializeField] private float _jumpForce = 10f;
    private bool isJumped;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isJumped = false;
    }

    private void Update()
    {
        isJumped = Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        if (isJumped)
        {
            rb.AddForce(transform.up * _jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (moveDirection != Vector3.zero)
        {
            //для физического движения
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime));
            if (targetRotation == transform.rotation)
                rb.MovePosition(transform.position + moveDirection * _speed * Time.fixedDeltaTime);
        }
    }
}