using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectsVisible : MonoBehaviour {

    // Use this for initialization

    public bool makeItInvisible = false;
	void Start () {
        if (makeItInvisible)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnKey()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
