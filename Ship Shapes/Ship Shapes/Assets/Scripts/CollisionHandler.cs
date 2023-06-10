using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                Debug.Log("You have made it through this challenge!");
                LoadNextLevel();
                break;
            default:
                ReloadLevel();
                break;
        }
    }

    int getCurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    void ReloadLevel()
    {
        //reload current level on death
        SceneManager.LoadScene(getCurrentLevel());
    }

    void LoadNextLevel(){
        //load the next level on win
        SceneManager.LoadScene(getCurrentLevel() + 1);
    }
}
