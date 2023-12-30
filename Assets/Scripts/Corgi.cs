using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    // 강아지 상태
    public enum state
    {
        Idle,
        Move,
        Sit,
        Turn,
        Eat
    };

    public state cState = state.Idle; // 기본상태 : Idle

    void Start()
    {
        
    }

    void Update()
    {
        checkState();
    }

    void checkState()
    {
        switch(cState)
        {
            case state.Idle:

                break;

            case state.Move:

                break;

            case state.Sit:

                break;

            case state.Turn:

                break;

            case state.Eat:

                break;
        }
    }
}
