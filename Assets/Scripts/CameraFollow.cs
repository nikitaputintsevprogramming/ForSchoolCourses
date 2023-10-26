using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Transform _target;
    [SerializeField] public float _smoothSpeed = 0.125f;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        _offset = new Vector3(0, 2, -3);
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = _target.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(_target);
    }
}