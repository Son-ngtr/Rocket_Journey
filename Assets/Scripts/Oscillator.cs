using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] float speed = 0.3f;
    [SerializeField] Vector3 movementVector = new Vector3 (0f, 4f, 0f);

    Vector3 startPosition;
    Vector3 endPosition;
    Vector3 randomPosition;
    float movementFactor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        randomPosition = new Vector3 (startPosition.x, Random.Range(startPosition.y, startPosition.y + movementVector.y), startPosition.z);
        endPosition = startPosition + movementVector;
        transform.position = randomPosition;
    }

    // Update is called once per frame
    void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(startPosition, endPosition, movementFactor);
    }
}
