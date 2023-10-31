using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleLogger : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Debug.LogFormat("Horizontal:{0} Vertical:{1}", horizontal, vertical);
    }
}
