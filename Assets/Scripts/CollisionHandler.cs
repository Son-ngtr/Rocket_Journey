using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip checkpointSound;
    [SerializeField] AudioClip fuelSound;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;

    [SerializeField] float delayTime = 1.2f;

    AudioSource audioSource;

    bool isControllable = true;
    bool isCollidable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Keyboard.current.shiftKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
        else if (Keyboard.current.ctrlKey.wasPressedThisFrame)
        {
            isCollidable = !isCollidable;
            Debug.Log("collision's turned on :" + isCollidable);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isControllable || !isCollidable)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Checkpoint":
                Debug.Log("Reach a checkpoint");
                break;
            case "Fuel":
                Debug.Log("Absorbed fuel");
                PlaySound(fuelSound);
                break;
            case "Finish":
                Debug.Log("Done, nice landing !!!");
                StartLoadingNextLevelSequence();
                break;
            default:
                Debug.Log("U crash !!!");
                StartCrashSequence();
                break;
        }
    }

    private void StartLoadingNextLevelSequence()
    {
        // todo add sfx and particles
        isControllable = false;
        audioSource.PlayOneShot(successSFX);
        successParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayTime);
    }

    void StartCrashSequence()
    {
        // todo add sfx and particles
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        crashParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayTime);
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }

    void PlaySound(AudioClip sound)
    {
        if (sound != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }

}
