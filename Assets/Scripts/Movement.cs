using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 1000f;
    [SerializeField] float rotateStrength = 68f;
    [SerializeField] AudioClip engineSound;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;


    AudioSource audioSource;
    Rigidbody rb;

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput > 0)
        {
            RotateLeft();
        }
        else if (rotationInput < 0)
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }
    private void RotateLeft()
    {
        ApplyRotation(-rotateStrength);
        if (!leftThrustParticles.isPlaying)
        {
            rightThrustParticles.Stop();
            leftThrustParticles.Play();
        }
    }
    private void RotateRight()
    {
        ApplyRotation(rotateStrength);
        if (!rightThrustParticles.isPlaying)
        {
            leftThrustParticles.Stop();
            rightThrustParticles.Play();
        }
    }

    private void StopRotating()
    {
        rightThrustParticles.Stop();
        leftThrustParticles.Stop();
    }



    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        rb.transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }

    private void ProcessThrust()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (thrust.IsPressed() || rotationInput != 0)
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineSound);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }


}
