using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private Transform closedPosition;
    [SerializeField] private Transform openPosition;
    [SerializeField] private float doorSpeed = 1;
    [SerializeField] protected float eps = 0.005f;


    private float doorNormalzedPosition = 0;
    bool isOpen = false;
    bool buttonEnabled = true;


    void Update()
    {
        door.position = Vector3.Lerp(closedPosition.position, openPosition.position, doorNormalzedPosition);

        if (isOpen)
        {
            if (!isAtTarget(door.position, openPosition.position))
                doorNormalzedPosition += Time.deltaTime * doorSpeed;
            else
                buttonEnabled = true;
        }
        else
        {
            if (!isAtTarget(door.position, closedPosition.position))
                doorNormalzedPosition -= Time.deltaTime * doorSpeed;
            else
                buttonEnabled = true;
        }
    }

    public void toggleDoor()
    {
        if (buttonEnabled)
        {
            buttonEnabled = false;
            isOpen = !isOpen;
        }
    }

    public void openDoor()
    {
        if (buttonEnabled)
        {
            buttonEnabled = false;
            isOpen = true;
        }
    }

    public void closeDoor()
    {
        if (buttonEnabled)
        {
            buttonEnabled = false;
            isOpen = false;
        }
    }



    protected bool isAtTarget(Vector3 currentPos, Vector3 target)
    {
        return ((target - currentPos).magnitude <= eps);
    }
}
