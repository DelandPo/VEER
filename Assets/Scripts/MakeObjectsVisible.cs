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
            //gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetObjectActive()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        //gameObject.SetActive(false);
    }
}
