using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopWelding : Workshop
{
    [SerializeField] private Animator weldRobot;

    void Start()
    {
        car.position = carInitialPosition.position;
    }

    void Update()
    {
        updateCarPosition();
    }

    public void startMoveToTarget()
    {
        if (Manufacture.instance.GetState() != States.idle) return;
        carMovingToTarget = true;
    }


    public void startWelding()
    {
        if (Manufacture.instance.GetState() != States.idle) return;
        if (!carIsAtTarget) return;
        if (finished) return;

        Manufacture.instance.SetState(States.welding);
        weldRobot.SetTrigger("weld");
    }
}
