using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    private void Start()
    {

    }

    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, 2 * Time.deltaTime);
    }
}
