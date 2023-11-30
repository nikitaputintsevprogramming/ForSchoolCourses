using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour
{
    [SerializeField] private Transform _blackHole;
    [SerializeField] private float _speed;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.RotateAround(_blackHole.position, Vector3.up, _speed * Time.deltaTime);
    }
}
