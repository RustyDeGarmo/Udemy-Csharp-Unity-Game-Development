using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                Debug.Log("You have made it through this challenge!");
                StartWinSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        //TODO add effects for crashing
        GetComponent<Movement>().enabled = false;
        GetComponent<AudioSource>().Stop();
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartWinSequence()
    {
        //TODO add effects for win
        GetComponent<Movement>().enabled = false;
        GetComponent<AudioSource>().Stop();
        Invoke("LoadNextLevel", levelLoadDelay);
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
        //load the next level on win.
        //if this level is the last level, load the first level
        if(getCurrentLevel() >= SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(getCurrentLevel() + 1);
        }
    }
}
