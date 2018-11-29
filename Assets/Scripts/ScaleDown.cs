using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScaleDown : MonoBehaviour
{
    private GameObject CameraRig;

    void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("ScaleDown");

        foreach (GameObject gameObject in objects)
        {
            gameObject.transform.localScale = gameObject.transform.localScale / 1000;
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}
