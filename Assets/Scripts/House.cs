using UnityEngine;

public class House : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the house around its Y axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
