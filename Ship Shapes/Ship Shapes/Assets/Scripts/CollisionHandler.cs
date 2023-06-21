using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip collisionAudio;
    [SerializeField] AudioClip landingPadAudio;
    [SerializeField] ParticleSystem collisionParticles;
    [SerializeField] ParticleSystem landingPadParticles;
    

    AudioSource audioSource;

    bool isTransitioning = false;
    bool debugMode = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        DebugControls();

    }

    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning || debugMode){ return; }
        
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
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(collisionAudio);
        collisionParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartWinSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(landingPadAudio);
        landingPadParticles.Play();
        GetComponent<Movement>().enabled = false;
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

    void DebugControls()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            debugMode = !debugMode;
        }
    }
}
