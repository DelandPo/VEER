using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Reset : MonoBehaviour {

    private void Awake()
    {
        SceneState.sceneTo = null;
        SceneState.alreadyStarted = false;
        SceneState.gamePlayed = false;
    }

}
