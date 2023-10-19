using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform companion;
    [SerializeField] private Transform companion2;
    [SerializeField] private Transform playerMTV;
    [SerializeField] private Transform playerLerp;

    [SerializeField] private float speed = 0.1f;

    [SerializeField] private float lengthRay = 10f;


    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {
        PlayerMove();
        Companion();
        Companion2();
        PlayerCatchMTV();
        PlayerCatchLerp();
    }

    private void PlayerMove()
    {
        Vector3 PlayerPos = new Vector3(0, 0, speed) * Time.deltaTime;
        player.Translate(PlayerPos) ;
        Debug.DrawRay(player.localPosition, player.forward * lengthRay, Color.white);
    }

    private void Companion()
    {
        companion.RotateAround(player.position, companion.up, speed);
        companion.LookAt(playerMTV.position);
        Debug.DrawRay(companion.position, companion.forward * lengthRay, Color.red);

    }

    private void Companion2()
    {
        companion2.RotateAround(player.position, companion2.up, -speed);
        companion2.LookAt(playerLerp.position);
        Debug.DrawRay(companion2.position, companion2.forward * lengthRay, Color.red);
    }

    private void PlayerCatchMTV()
    {
        float MTVSpeed = speed * Time.deltaTime;
        playerMTV.position = Vector3.MoveTowards(playerMTV.position, player.position, MTVSpeed);
        Debug.DrawRay(playerMTV.localPosition, playerMTV.forward * lengthRay, Color.yellow);

    }

    private void PlayerCatchLerp()
    {
        float lerpSpeed = speed  * Time.deltaTime;
        playerLerp.position = Vector3.Lerp(playerLerp.position, player.position, lerpSpeed);
        Debug.DrawRay(playerLerp.localPosition, playerLerp.forward * lengthRay, Color.yellow);

    }
}