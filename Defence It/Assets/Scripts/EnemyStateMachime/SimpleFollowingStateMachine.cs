using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollowingStateMachine : MonoBehaviour
{
    StateMachineStatets CurrentState;
    
    void Start()
    {
        CurrentState = StateMachineStatets.Idel;
    }

    
    void Update()
    {
        switch (CurrentState)
        {
            case StateMachineStatets.Idel:
                break;
            case StateMachineStatets.Following:
                break;
            case StateMachineStatets.Attacking:
                break;
            case StateMachineStatets.Die:
                break;
            default:Debug.LogError("Нет Состояние в машине состояний");
                break;
        }
    }
}
