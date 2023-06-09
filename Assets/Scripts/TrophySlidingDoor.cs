using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophySlidingDoor : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public Light trophyLight;

    Vector3 door1Origin;
    Vector3 door2Origin;

    public float door1Target;
    public float door2Target;

    private bool openDoor = false;
    private float rotationSpeed = 1f;
    private float lightIntensity = 1f;
    private float lightIncreaseSpeed = 1f;

    void Start()
    {
        door1Origin = door1.transform.localPosition;
        door2Origin = door2.transform.localPosition;
    }

    void Update()
    {
        if (openDoor)
        {
            Vector3 door1TargetPosition = new Vector3(door1Target, door1Origin.y, door1Origin.z);
            door1.transform.localPosition = Vector3.MoveTowards(door1.transform.localPosition, door1TargetPosition, rotationSpeed * Time.deltaTime);

            Vector3 door2TargetPosition = new Vector3(door2Target, door2Origin.y, door2Origin.z);
            door2.transform.localPosition = Vector3.MoveTowards(door2.transform.localPosition, door2TargetPosition, rotationSpeed * Time.deltaTime);

            // Increase light intensity gradually
            if (trophyLight.intensity < 1f)
            {
                lightIntensity += lightIncreaseSpeed * Time.deltaTime;
                trophyLight.intensity = Mathf.Clamp01(lightIntensity);
            }
        }
        else
        {
            door1.transform.localPosition = Vector3.MoveTowards(door1.transform.localPosition, door1Origin, rotationSpeed * Time.deltaTime);
            door2.transform.localPosition = Vector3.MoveTowards(door2.transform.localPosition, door2Origin, rotationSpeed * Time.deltaTime);

            // Reset light intensity
            if (trophyLight.intensity > 0f)
            {
                lightIntensity -= lightIncreaseSpeed * Time.deltaTime;
                trophyLight.intensity = Mathf.Clamp01(lightIntensity);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openDoor = true;
            Debug.Log("Player in door zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openDoor = false;
        }
    }
}
