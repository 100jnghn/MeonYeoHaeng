using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Unity.VisualScripting;

public class GumScript : MonoBehaviour
{
    public GameObject dogObject;
    public GameObject pos;
    void Start()
    {
        dogObject = GameObject.FindGameObjectWithTag("Dog");
        pos = GameObject.FindGameObjectWithTag("Pos");
        UnityEngine.Debug.Log(dogObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    UnityEngine.Debug.Log("Trigger entered with" + other.gameObject.tag);
    //    if (other.gameObject.tag == "Dog")
    //    {
    //        this.transform.parent = dogObject.transform;
    //        this.transform.position = pos.transform.position;
    //        this.transform.rotation = pos.transform.rotation;                 충돌감지로 인식-> rigidbody때문에 변수많음
    //        UnityEngine.Debug.Log("dog");                                     안정적으로 그냥 speechRecognition 스크립트랑 연동
    //    }                                                                        
    //}
    public void biteGum()
    {
        UnityEngine.Debug.Log("biteGum");
        this.transform.parent = dogObject.transform;
        this.transform.position = pos.transform.position;
        this.transform.rotation = pos.transform.rotation;
    }
}
