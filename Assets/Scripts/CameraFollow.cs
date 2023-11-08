using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = _target.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(_target);
    }
}
