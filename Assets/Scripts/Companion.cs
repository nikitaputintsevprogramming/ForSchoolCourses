using System.Collections;
using UnityEngine;

public class Companion : Follower
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lengthRay;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - Target;
    }

    protected override void Move()
    {
        transform.position = Target + _offset;
        transform.RotateAround(Target, Vector3.up, Speed);
        transform.LookAt(_target.position);
        _offset = transform.position - Target;
        Debug.DrawRay(transform.position, transform.forward * _lengthRay, Color.red);
    }
}
