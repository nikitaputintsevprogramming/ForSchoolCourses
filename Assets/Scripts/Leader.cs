using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed;

    private int _currentWaypoints;

    private void Update()
    {
        if(transform.position == _wayPoints[_currentWaypoints].position)
        {
            _currentWaypoints++;

            if(_currentWaypoints >= _wayPoints.Length)
            {
                _currentWaypoints = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWaypoints].position, _speed * Time.deltaTime);
    }
}
