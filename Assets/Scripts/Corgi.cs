using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    // ������ ����
    public enum state
    {
        Idle,
        Move,
        Sit,
        Turn,
        Eat
    };

    public state cState = state.Idle; // �⺻���� : Idle

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
