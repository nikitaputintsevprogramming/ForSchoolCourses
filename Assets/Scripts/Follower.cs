using System.Collections;
using UnityEngine;

public abstract class Follower : MonoBehaviour
{
    [SerializeField] private Transform _leader;
    [SerializeField] private float _speed;

    // В методичке написать почему мы сделали обращение и запретили лотсуп ко всему компоненту Transform или изменению поля _speed
    protected Vector3 Target => _leader.position;
    protected float Speed => _speed;

    protected abstract void Move();

    protected virtual void Update()
    {
        Move();
    }
}