using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;

    private int _currentWaipoint = 0;

    private void Update()
    {
        if(transform.position == _waypoints[_currentWaipoint].position)
        {
            _currentWaipoint = (_currentWaipoint + 1) % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaipoint].position, _speed * Time.deltaTime);
    }
}
