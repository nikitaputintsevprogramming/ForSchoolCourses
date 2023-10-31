using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    void Start()
    {
        
    }

    void Update()
    {
        float speed = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target.position, speed);
    }
}
