using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopPaint : Workshop
{
    [SerializeField] private Animator paintRobot;
      
    void Start()
    {
        
    }

    void Update()
    {
        updateCarPosition();
    }

    public void startMoveToTarget()
    {
        startMoveToTarget(0);
    }

    public void startPainting()
    {
        if (!carIsAtTarget) return;
        if (finished) return;

        Manufacture.instance.SetState(States.paint);
        paintRobot.SetTrigger("paint");
    }

}
