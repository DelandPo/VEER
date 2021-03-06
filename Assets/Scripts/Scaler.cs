﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour {

    private void Awake()
    {
        GameObject[] myGameObjects = GameObject.FindGameObjectsWithTag("ScaleDown");
        foreach(var v in myGameObjects)
        {
            v.transform.localScale = v.transform.localScale / 1000;
            v.transform.position = new Vector3(0, 0, 0);
            v.transform.rotation = new Quaternion(0,0,0,0);
        }
    }

}
