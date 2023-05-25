using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopEngine : Workshop
{
    [SerializeField] protected Animator EngineAnimator;

    // Start is called before the first frame update
    void Start()
    {
        updateTvText();
    }

    // Update is called once per frame
    void Update()
    {
        updateCarPosition();
    }

    public void startMoveToTarget()
    {
        startMoveToTarget(1);
    }

    public void startSetEngine()
    {
        if (Manufacture.instance.GetState() != States.paint) return;
        if (!carIsAtTarget) return;
        if (finished) return;
        if (isEmergencyStopped) return;

        Manufacture.instance.SetState(States.engine);
        EngineAnimator.SetTrigger("engine");
    }
}
