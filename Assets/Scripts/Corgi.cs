using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Diagnostics;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
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
    public GameObject DogGum;
    public GameObject clone;
    public GameObject saliva;
    public GameObject crumbles;
    public GumScript gumScript;
    public AudioSource audioSource;
    public AudioClip waitSound;
    public AudioClip barkSound;
    public AudioClip eatingSound;
    public AudioClip JumpSound;
    public AudioClip idleSound;


    Animator anim;

    IEnumerator BiteSeq()
    {
        UnityEngine.Debug.Log("bite sequence entered");
        cState = Corgi.state.Eat;
        //doEat();

        anim.SetTrigger("doEat");
        saliva.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        if (audioSource != null && eatingSound != null)
        {
            audioSource.clip = eatingSound;
            audioSource.loop = false;
            audioSource.Play();
        }
        gumScript.biteGum();
        crumbles.SetActive(true);

        yield return new WaitForSeconds(2.0f);
        Destroy(clone);
        yield return new WaitForSeconds(0.5f);

        crumbles.SetActive(false);
        cState = state.Idle;

        audioSource.clip = idleSound;
        audioSource.loop = true;
        audioSource.Play();


    }
    IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
    IEnumerator PlaySoundAfterAnother(AudioClip a, AudioClip b)
    {
        yield return new WaitForSeconds(0.5f);
        if (audioSource != null && a != null)
        {
            audioSource.loop = false;
            audioSource.clip = a;
            audioSource.Play();
        }
        yield return new WaitForSeconds(a.length);

        if (cState == state.Wait)
        {
            audioSource.clip = b;
            audioSource.loop = true;
            audioSource.Play();
        }

    }
    IEnumerator Playidle()
    {
        if (audioSource != null && JumpSound != null)
        {
            audioSource.loop = false;
            audioSource.clip = JumpSound;
            audioSource.Play();
        }
        yield return new WaitForSeconds(JumpSound.length);

        if (cState == state.Idle)
        {
            audioSource.clip = idleSound;
            audioSource.loop = true;
            audioSource.Play();
        }

    }
    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

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
        //if (cState == state.Idle && audioSource.clip != idleSound)
        //{
        //    audioSource.loop = true;
        //    audioSource.clip = idleSound;
        //    audioSource.Play();
        //}
        //else if (cState != state.Idle && audioSource.clip == idleSound)
        //{
        //    audioSource.Stop();
        //
        //}
        //

    }
    void changeFirstPlace()
    {
        transform.position = new Vector3(0, 1000, 0);
    }

    public void showDog()
    {
        transform.position = startPos.transform.position;
        //if (audioSource != null && JumpSound != null)
        //{
        //    audioSource.clip = JumpSound;
        //    audioSource.Play();
        //}
        StartCoroutine(Playidle());
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

        cState = state.Idle;
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
        StartCoroutine(BiteSeq());

    }
    public void doWait()
    {
        anim.SetTrigger("doWait");
        cState = state.Wait;

        if (audioSource != null && waitSound != null)
        {
            audioSource.clip = waitSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void doBark()
    {
        anim.SetTrigger("doBark");
        cState = state.Wait;

        StartCoroutine(PlaySoundAfterAnother(barkSound, waitSound));

    }
    public void doLook()
    {
        transform.LookAt(player.transform.position);
    }

    public void makeSnack()
    {
        cState = Corgi.state.Wait;
        doWait();
        clone = Instantiate(DogGum, new Vector3(0, 1, 0), DogGum.transform.rotation);
        gumScript = clone.GetComponent<GumScript>();
        clone.SetActive(true);
        saliva.SetActive(true);
    }
}


