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
    //        this.transform.rotation = pos.transform.rotation;                 �浹������ �ν�-> rigidbody������ ��������
    //        UnityEngine.Debug.Log("dog");                                     ���������� �׳� speechRecognition ��ũ��Ʈ�� ����
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
