using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenArea : MonoBehaviour
{
    
    public GameObject door1;
    public GameObject door2;

    Quaternion door1Origin;
    Quaternion door2Origin;

    public float door1Target;
    public float door2Target;

    private bool openDoor = false;
    private float rotationSpeed = 50;

    void Start()
    {
        door1Origin = door1.transform.rotation;
        door2Origin = door2.transform.rotation;
    }

    void Update()
    {
        if (openDoor)
        {
            Quaternion door1TargetRotation = Quaternion.Euler(door1Origin.eulerAngles.x , 0f, door1Target);
            door1.transform.rotation = Quaternion.RotateTowards(door1.transform.rotation, door1TargetRotation, Time.deltaTime * rotationSpeed);

            Quaternion door2TargetRotation = Quaternion.Euler(door2Origin.eulerAngles.x, 0f, -door2Target);
            door2.transform.rotation = Quaternion.RotateTowards(door2.transform.rotation, door2TargetRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            door1.transform.rotation = Quaternion.RotateTowards(door1.transform.rotation, door1Origin, Time.deltaTime * rotationSpeed);
            door2.transform.rotation = Quaternion.RotateTowards(door2.transform.rotation, door2Origin, Time.deltaTime * rotationSpeed);
        }
    }







    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openDoor = true;
            print("player in door zone");
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
