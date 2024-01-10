using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcollition : MonoBehaviour
{
    // Specify the tag you want to detect collisions with
    public string targetTag = "YourTargetTag";

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Collision with the specified tag detected
            Debug.Log("Collision with object of tag: " + targetTag);
        }
    }
}
