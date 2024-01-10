using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform player;
    private Rigidbody playerRB;
    public Vector3 offset;
    public float speed;

    private void Start()
    {
        playerRB =player.GetComponent<Rigidbody>();

    }

    public void LateUpdate()
    {
        Vector3 playerforword = (playerRB.velocity + player.forward).normalized;

        transform.position = Vector3.Lerp(transform.position,
            player.position + player.transform.TransformVector(offset),
    //        + playerforword * (-5f),
            speed * Time.deltaTime) ;

        transform.LookAt (player);
    }
}
