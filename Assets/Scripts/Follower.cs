using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Follower : MonoBehaviour
{
    [SerializeField] private Transform _leader;
    [SerializeField] private float _speed;

    protected Vector3 Target => _leader.position;
    protected float Speed => _speed;

    protected abstract void Move();

    private void Update()
    {
        Move();
    }
}
