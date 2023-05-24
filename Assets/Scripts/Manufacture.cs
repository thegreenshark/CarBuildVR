using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Manufacture : MonoBehaviour
{
    private static int car_counter = 0; // счётчик машин
    private static States state = States.idle; // состояние графа-автомата
    // набор ссылок на кнопки и индикаторы (на руке которые)

    public static Manufacture instance = null; // instance
    private static readonly object padlock = new object(); // lock object

    public List<Workshop> workshops;

    private void Awake()
    {
        // создаём объект производства
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(States state)
    {
        Manufacture.state = state;
        Debug.Log($"set state to {state}");
    }

    public States GetState()
    {
        return state;
    }

    public void ResetAll()
    {
        
    }

}


public enum States
{
    idle,
    welding,
    paint,
    engine,
    seats_lights_glass,
    doors_hood_trunk,
    wheels
}
