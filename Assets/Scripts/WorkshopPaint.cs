using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopPaint : Workshop
{
    [SerializeField] private Animator paintRobot;

    [SerializeField] private Color color1;
    [SerializeField] private Color color2;
    [SerializeField] private Color color3;
    [SerializeField] private Color color4;

    private Color chosenColor;
    private bool colorChoiceLocked = false;

    void Start()
    {
        updateTvText();
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
        if (isEmergencyStopped) return;

        colorChoiceLocked = true;
        Manufacture.instance.SetState(States.paint);
        paintRobot.SetTrigger("paint");
    }


    public override void setFinished()
    {
        base.setFinished();
        car.GetChild(0).GetComponent<MeshRenderer>().material.color = chosenColor;
    }

    public override void emergencyStop()
    {
        paintRobot.speed = 0;
        isEmergencyStopped = true;
    }



    public Color getChosenColor()
    {
        return chosenColor;
    }



    public void chooseColor1()
    {
        chosenColor = color1;
    }
    public void chooseColor2()
    {
        chosenColor = color2;
    }
    public void chooseColor3()
    {
        chosenColor = color3;
    }
    public void chooseColor4()
    {
        chosenColor = color4;
    }


}
