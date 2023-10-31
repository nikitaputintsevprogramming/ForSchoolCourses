using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(transform.position, transform.up, 2f * Time.deltaTime);
    }
}
