using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : Follower
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lengthRay;

    protected override void Move()
    {
        transform.RotateAround(_leader.position, Vector3.up, _speed);
        transform.LookAt(_target.position);
        Debug.DrawRay(transform.position, transform.forward * _lengthRay, Color.red);
    }
}
