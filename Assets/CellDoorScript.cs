using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDoorScript : MonoBehaviour
{
    public GameObject KeyElement;

    private bool readyToBeUnlocked;
    private Animator animator;

	// Use this for initialization
	void Start () {
        readyToBeUnlocked = false;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BeginExplosion()
    {
        Invoke("Explode", 5);
    }

    private void Explode()
    {
        animator.SetBool("Explosion", true);
    }

    public bool IsReadyToBeUnlocked()
    {
        return readyToBeUnlocked;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(KeyElement))
        {
            //Key element has entered trigger
            if (other.gameObject.GetComponent<BucketScript>().IsReadyToUnlock())
            {
                readyToBeUnlocked = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(KeyElement))
        {
            //Key element has left trigger
            readyToBeUnlocked = false;
        }
    }
}
