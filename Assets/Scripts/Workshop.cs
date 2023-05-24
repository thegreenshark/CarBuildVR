using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Workshop : MonoBehaviour
{
    [SerializeField] protected Transform car;
    [SerializeField] protected Transform carInitialPosition;
    [SerializeField] protected Transform carTargetPosition;
    [SerializeField] protected GameObject newCarPartPrefab;
    [SerializeField] protected TextMeshProUGUI tvText;
    [SerializeField] protected DoorController door;
    [SerializeField] protected string tvString;
    [SerializeField] protected float carMoveSpeed = 1;
    [SerializeField] protected float eps = 0.005f;

    protected int counter = 0;
    protected bool finished = false;
    protected float carNormalzedPosition = 0;
    protected bool carMovingToTarget = false;
    protected bool carIsAtTarget = false;
    protected bool isEmergencyStopped = false;

    //TODO
    // ссылка на текст на табло (на канвасе)
    // метод resetAll()


    protected bool isAtTarget(Vector3 currentPos, Vector3 target)
    {
        return ( (target - currentPos).magnitude <= eps );
    }

    protected void updateCarPosition()
    {
        if (carMovingToTarget)
        {
            car.position = Vector3.Lerp(carInitialPosition.position, carTargetPosition.position, carNormalzedPosition);
            carNormalzedPosition += Time.deltaTime * carMoveSpeed;
            if (isAtTarget(car.position, carTargetPosition.position))
            {
                carMovingToTarget = false;
                carIsAtTarget = true;
            }
        }
    }


    protected void startMoveToTarget(int previousWorkshopIndex)
    {
        if (Manufacture.instance.workshops[previousWorkshopIndex].isFinished() == false)
            return;

        if (isEmergencyStopped) return;

        if (door != null)
            door.openDoor();

        carMovingToTarget = true;
    }


    public bool isFinished()
    {
        return finished;
    }


    public virtual void setFinished()
    {
        finished = true;
        if (newCarPartPrefab != null)
            Instantiate(newCarPartPrefab, car);

        counter++;
        updateTvText();
    }

    public virtual void emergencyStop()
    {
        isEmergencyStopped = true;
    }


        public void resetCounter()
    {
        counter = 0;
        updateTvText();
    }

    protected void updateTvText()
    {
        tvText.text = tvString + $": {counter}";
    }

}
