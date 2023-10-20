using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 pos;
    [SerializeField] private float speed;

    private void LateUpdate()
    {
        float lerpSpeed = speed * Time.deltaTime;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, player.position + pos, lerpSpeed);
    }
}
