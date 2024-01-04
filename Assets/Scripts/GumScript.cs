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

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Trigger entered with" + other.gameObject.tag);
        if (other.gameObject.tag == "Dog")
        {
            this.transform.parent = dogObject.transform;
            this.transform.position = pos.transform.position;
            this.transform.rotation = pos.transform.rotation;
            UnityEngine.Debug.Log("dog");
        }
    }
}
