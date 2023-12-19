using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObject : MonoBehaviour
{
    public GameObject model;

    void Start()
    {
        model.SetActive(false);
    }

    void Update()
    {
        
    }

    public void showModel()
    {
        model.SetActive(true);
    }
}
