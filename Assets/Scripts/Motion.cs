using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(transform.up * 2f * Time.deltaTime);
    }
}
