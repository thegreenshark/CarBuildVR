using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWorkshopFinished : MonoBehaviour
{
    public Workshop wsh;
    public int counter = 1;
    public void setFinished()
    {
        counter--;
        if (counter <= 0){
            wsh.setFinished();
            return;
        }
    }

}
