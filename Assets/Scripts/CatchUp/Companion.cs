using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : Follower
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lengthRay;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _leader.position;
    }

    protected override void Move()
    {
        transform.position = _leader.position + _offset;
        transform.RotateAround(_leader.position, Vector3.up, _speed);
        transform.LookAt(_target.position);
        _offset = transform.position - _leader.position;
        Debug.DrawRay(transform.position, transform.forward * _lengthRay, Color.red);
    }
}
