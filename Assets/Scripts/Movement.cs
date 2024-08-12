using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    

    [SerializeField] float mainThrust = 1000;
    [SerializeField] float mainRotate = 50;

    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

    Rigidbody rb;

    AudioSource audioSource;

    ParticleSystem particleSystem;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Pressed Space - Thrusting");
            

            rb.AddRelativeForce(0, 1*mainThrust*Time.deltaTime, 0);//vector3.up
            
            if (audioSource.isPlaying== false)
            {
                //audioSource.Play();
                audioSource.PlayOneShot(mainEngine);
            }

            if (mainEngineParticles.isPlaying == false)
            {
                
                mainEngineParticles.Play();

            }

        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
       
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Rotate Left");
            ApplyRotation(mainRotate);
            if (rightThrusterParticles.isPlaying == false)
            {
                rightThrusterParticles.Play();
            }
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Rotate Right");
            ApplyRotation(-mainRotate);

            if (leftThrusterParticles.isPlaying == false)
            {
                leftThrusterParticles.Play();
            }
        }

        
        else
        {
            leftThrusterParticles.Stop();
            rightThrusterParticles.Stop();  
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(0, 0, 1 * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }
}
