using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    // 강아지 상태
    public enum state
    {
        Start,
        Idle,
        Wait,
        Move,
        Sit,
        SitUp,
        Turn,
        Eat,
        Look,
        Bark
    };

    public state cState = state.Idle; // 기본상태 : Idle

    public GameObject player;
    public GameObject startPos;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        cState = state.Start;
        //anim.SetTrigger("doStart");
        //transform.position = Vector3.MoveTowards(transform.position, startPos.transform.position, 1f);
        changeFirstPlace();
    }

    void Update()
    {
        //checkState();
        //jumpToStartPos();
    }

    void changeFirstPlace()
    {
        transform.position = new Vector3(0, 1000, 0);
    }

    public void showDog()
    {
        transform.position = new Vector3(-1, 0, 2);
        jumpToStartPos();
    }

    public void jumpToStartPos()
    {
        anim.SetTrigger("doStart");
        if (cState == state.Start)
        {
            // transform.position = Vector3.MoveTowards(transform.position, startPos.transform.position, 1f * Time.deltaTime);

            // 목표 지점에 도달하면 상태를 변경합니다.
            if (transform.position == startPos.transform.position)
            {
                cState = state.Idle;
            }
        }
    }

    void checkState()
    {
        /*// 애니메이션 변경을 코루틴으로 작성해야???
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
        UnityEngine.Debug.Log("Corgi script entered");
        anim.SetTrigger("doEat");

        cState = state.Idle;
    }
    public void doWait()
    {
        anim.SetTrigger("doWait");

        cState = state.Wait;
    }
    public void doBark()
    {
        anim.SetTrigger("doBark");

        cState = state.Idle;
    }
    public void doLook()
    {
        transform.LookAt(player.transform.position);
    }
}
