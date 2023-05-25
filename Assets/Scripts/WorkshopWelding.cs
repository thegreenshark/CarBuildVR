using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopWelding : Workshop
{
    [SerializeField] private Animator weldRobot;

    void Start()
    {
        car.position = carInitialPosition.position; // установка машины в начальную точку (надо только в этом скрипте)
        updateTvText();
    }

    void Update()
    {
        updateCarPosition();
    }

    public void startMoveToTarget()
    {
        if (Manufacture.instance.GetState() != States.idle) return;
        if (isEmergencyStopped) return;

        carMovingToTarget = true;
    }


    public void startWelding()
    {
        if (Manufacture.instance.GetState() != States.idle) return;
        if (!carIsAtTarget) return;
        if (finished) return;
        if (isEmergencyStopped) return; 

        Manufacture.instance.SetState(States.welding);
        weldRobot.SetTrigger("weld");
    }

    public override void emergencyStop()
    {
        weldRobot.speed = 0;
        isEmergencyStopped = true;
    }

}
