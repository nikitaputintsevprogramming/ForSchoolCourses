using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private float _gravitationalForce = 5f;
    [SerializeField] private Rigidbody[] _planets;

    private void FixedUpdate()
    {
        foreach(Rigidbody rigidbody in _planets)
        {
            Vector3 direction = transform.position - rigidbody.position;
            float distance = direction.magnitude;

            if(distance > 0)
            {
                Vector3 force = (direction / (distance * distance)) * _gravitationalForce;
                rigidbody.AddForce(force);
            }
        }
    }
}
