using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    // ������ ����
    public enum state
    {
        Idle,
        Wait,
        Move,
        Sit,
        SitUp,
        Turn,
        Eat,
        Look
    };

    public state cState = state.Idle; // �⺻���� : Idle

    public GameObject player;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //checkState();
    }

    void checkState()
    {
        /*// �ִϸ��̼� ������ �ڷ�ƾ���� �ۼ��ؾ�???
        switch(cState)
        {
            case state.Idle:

                break;

            case state.Move:

                break;

            case state.Sit:
                StartCoroutine(doSit());
                break;

            case state.SitUp:
                StartCoroutine(doSitUp());
                break;

            case state.Turn:
                StartCoroutine(doTurn());
                break;

            case state.Eat:
                StartCoroutine(doEat());
                break;

            case state.Look: 
                transform.LookAt(player.transform.position);
                break;
        }*/
    }

    public void doSit()
    {
        anim.SetTrigger("doSit");

        cState = state.Wait;
    }

    public void doSitUp()
    {
        anim.SetTrigger("doSitUp");

        cState = state.Idle;
    }

    public void doTurn()
    {
        anim.SetTrigger("doTurn");

        cState = state.Idle;
    }

    public void doEat()
    {
        anim.SetTrigger("doEat");

        cState = state.Idle;
    }

    public void doLook()
    {
        transform.LookAt(player.transform.position);
    }
}
