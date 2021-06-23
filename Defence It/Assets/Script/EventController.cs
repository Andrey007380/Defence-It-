using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventController
{
    public delegate void Timestoped();
    public static event Timestoped OnTimeStoped;
    void OnTimeStop(bool Paused)
    { 
        if (Time.timeScale == 0)
        {
            OnTimeStoped();
            Paused = true;
        }
    }
}
