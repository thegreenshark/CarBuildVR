using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopDoorsHoodTrunk : Workshop
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateCarPosition();
    }

    public void startMoveToTarget()
    {
        startMoveToTarget(3);
    }
}
