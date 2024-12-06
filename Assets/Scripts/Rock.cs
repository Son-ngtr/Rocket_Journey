using UnityEngine;

public class Rock : MonoBehaviour
{
    Vector3 scaleOfRocks;
    Vector3 rotationOfRocks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scaleOfRocks = new Vector3(Random.Range(3f, 5f), Random.Range(3f, 5f), Random.Range(3f, 5f));
        rotationOfRocks = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));

        Debug.Log("Scale of Rocks: " + scaleOfRocks);
        Debug.Log("Rotation of Rocks: " + rotationOfRocks);
        transform.localScale = scaleOfRocks;
        transform.rotation = Quaternion.Euler(rotationOfRocks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
