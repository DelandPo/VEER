using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.EditorVR.Core;
[ExecuteInEditMode]
public class Reset : MonoBehaviour
{

    private void Awake()
    {
        if(SceneState.sceneTo != null && SceneState.alreadyStarted == true && SceneState.gamePlayed == true)
        {
            UnityEditor.EditorApplication.isPlaying = true;
            UnityEditor.EditorApplication.isPlaying = false;
            UnityEditor.EditorApplication.isPlaying = true;
            UnityEditor.EditorApplication.isPlaying = false;
            StartCoroutine(Example());
            Debug.Log("In the awake function");
            SceneState.sceneTo = null;
            SceneState.alreadyStarted = false;
            SceneState.gamePlayed = false;
        }





    }
   
        IEnumerator Example()
        {
            yield return new WaitForSeconds(5);
            UnityEditor.EditorApplication.isPlaying = false;
            EditingContextManager.ShowEditorVR();
        }

       

}
