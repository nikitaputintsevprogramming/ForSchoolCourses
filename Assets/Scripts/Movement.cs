using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float speed;

    void Start()
    {

    }

    void Update()
    {
        player.position += new Vector3(0, 0, speed) * Time.deltaTime;
        print(player.gameObject.name);
    }
}