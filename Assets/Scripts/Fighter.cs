using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    
    [SerializeField] bool AIObject = true;


    // Amplitude of the hover effect
    public float hoverAmplitude = 0.5f;
    // Frequency of the hover effect
    public float hoverFrequency = 1f;
    // Original position of the spaceship
    private Vector3 originalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Store the original position of the spaceship
        originalPosition = transform.position;
        if (AIObject){
            mainEngineParticles.Play();
            leftThrustParticles.Play();
            rightThrustParticles.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new position using a sine wave for hovering effect
        float newY = originalPosition.y + Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;
        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
    }
}
