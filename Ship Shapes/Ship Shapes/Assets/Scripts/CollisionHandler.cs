using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Fuel":
                Debug.Log("Refueled! Let's go!");
                break;
            case "Finish":
                Debug.Log("You finished, you're a winner!");
                break;
            default:
                Debug.Log("Kaboom, you blew up!"); 
                break;
        }
    }
}
