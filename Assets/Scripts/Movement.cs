using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 180f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (moveDirection != Vector3.zero)
        {
            Vector3 newPosition = transform.position + moveDirection * _speed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            transform.position = newPosition;

            //Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            //rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime));
            //rb.MovePosition(transform.position + moveDirection * _speed * Time.fixedDeltaTime);
        }
    }
}