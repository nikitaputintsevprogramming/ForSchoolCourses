using System.Collections;
using UnityEngine;


public abstract class Follower : MonoBehaviour
{
    [SerializeField] protected Transform _leader;
    [SerializeField] protected float _speed;

    protected abstract void Move();

    protected virtual void Update()
    {
        Move();
    }
}