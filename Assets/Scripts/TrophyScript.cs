using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyScript : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float movementSpeed = 0.5f;
    public float movementAmount = 0.2f;

    private float initialY;

    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the trophy around the Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Move the trophy up and down
        float newY = initialY + Mathf.Sin(Time.time * movementSpeed) * movementAmount;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
