using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Horizontal;
    [SerializeField] private float Vertical;

    [SerializeField] private float speed;

    private void Start()
    {
        
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        //Debug.LogFormat("H:{0} V: {1}", Horizontal, Vertical);

        Vector3 playerPos = new Vector3(Horizontal, 0, Vertical) * speed * Time.deltaTime;
        gameObject.transform.Translate(playerPos);
    }
}
