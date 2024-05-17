using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
     GameOver gameOver;

    public void Start()
    {
        gameOver=GameObject.FindAnyObjectByType<GameOver>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "OBC")
        {
            Debug.Log("collided");
            gameOver.gameover();
        }
    }
}
