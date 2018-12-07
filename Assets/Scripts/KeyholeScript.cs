using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyholeScript : MonoBehaviour {

    private GameObject targetGameObject;
    private GameObject Key;
    private BoxCollider keyCollider;

	// Use this for initialization
	void Start () {
        targetGameObject = GameObject.FindGameObjectWithTag("SuccessMessage");
        Key = GameObject.FindGameObjectWithTag("SpawnKey");
        //keyCollider = Key.GetComponent<BoxCollider>;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /*private void OnTriggerEnter(Collider other)
    {
        targetGameObject.SendMessage("SetObjectActive");
    }*/

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SpawnKey")
        {
            targetGameObject.SendMessage("SetObjectActive");
            GameObject.FindGameObjectWithTag("Radio").GetComponent<AudioSource>().Stop();
            GameObject.FindGameObjectWithTag("Keyhole").GetComponent<AudioSource>().Play();
        }
    }
}
