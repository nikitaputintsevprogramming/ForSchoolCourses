using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;

    void Start()
    {

    }

    void LateUpdate()
    {
            Vector3 positionToGo = _player.transform.position + _offset;
            transform.position = positionToGo;
            transform.LookAt(_player.transform.position);
    }
}
