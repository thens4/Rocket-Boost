using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
    ParticleSystem particleSystem;

    [SerializeField] float levelLoadDelay = 2;

    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip succesAudio;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem succesParticles;

    bool isAlive = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        skipLevel();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isAlive == true) //if (isAlive == true) {return}
        {
            switch (other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("Dont worry its friendly");

                    break;

                case "Obstacle":
                    Debug.Log("Oh noo your dead now");
                    
                    startCrashSequance();

                    //Invoke("ReloadLevel", levelLoadDelay);
                    //ReloadLevel();

                    break;

                case "Finish":
                    Debug.Log("Heyy you did it well done");
                    
                    StartSuccesSequance();

                    //NextLevel();
                    break;

            }
        }  
    }

    void skipLevel()
    {
    if (Input.GetKey(KeyCode.L))
        {
            NextLevel();
        }
    }

    

    void startCrashSequance()
    {
        audioSource.Stop();

        audioSource.PlayOneShot(crashAudio);

        crashParticles.Play();

        GetComponent<Movement>().enabled = false;

        Invoke("ReloadLevel", levelLoadDelay);

        isAlive = false;



        //ReloadLevel();
    }
    void StartSuccesSequance()
    {
        audioSource.Stop();

        audioSource.PlayOneShot(succesAudio);

        succesParticles.Play();

        GetComponent<Movement>().enabled = false;

        Invoke("NextLevel", levelLoadDelay);

        isAlive = false;    
        
        
    }

    


    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            //SceneManager.LoadScene(0);
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }


    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    
}
