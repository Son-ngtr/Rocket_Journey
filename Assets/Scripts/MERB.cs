using UnityEngine;

public class MERB : MonoBehaviour
{
    // Speed of the car
    public float speed = 10f;
    // Radius of the circle
    public float circleRadius = 5f;

    // Update is called once per frame
    void Update()
    {
        // Move the car forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Calculate the angle to turn based on the circle radius
        float angle = speed / circleRadius;
        transform.Rotate(Vector3.up, angle * Time.deltaTime);
    }
}
