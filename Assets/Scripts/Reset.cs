﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.EditorVR.Core;
[ExecuteInEditMode]
public class Reset : MonoBehaviour
{
    public enum InteractableObjects {Hello, World}
    public InteractableObjects myObjects;

    private void Awake()
    {
        if(SceneState.sceneTo != null && SceneState.alreadyStarted == true && SceneState.gamePlayed == true)
        {
            //UnityEditor.EditorApplication.isPlaying = true;
           // StartCoroutine(Example());
            Debug.Log("In the awake function");
            SceneState.sceneTo = null;
            SceneState.alreadyStarted = false;
            SceneState.gamePlayed = false;
            myObjects = InteractableObjects.Hello;
        }


    }
   
        IEnumerator Example()
        {
            yield return new WaitForSeconds(2);
            //UnityEditor.EditorApplication.isPlaying = false;
            EditingContextManager.ShowEditorVR();
        }

       

}
