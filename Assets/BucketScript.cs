using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour
{
    public GameObject LockElement;

    public GameObject[] GunpowderElements;

    public GameObject IgnitionElement;

    private bool readyToUnlock;
    private int numKeysAdded;
    private MeshRenderer gunpowderMeshRenderer;


	// Use this for initialization
	void Start () {
        numKeysAdded = 0;
        gunpowderMeshRenderer = transform.Find("Gunpowder").GetComponent<MeshRenderer>();
        gunpowderMeshRenderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (readyToUnlock == false && CheckIfReadyToUnlock())
        {
            readyToUnlock = true;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < GunpowderElements.Length; i++)
        {
            if (other.gameObject.Equals(GunpowderElements[i]))
            {
                numKeysAdded++;
                AddColorToGunpowder();

                //Destroy key element so it cant be used again
                Destroy(GunpowderElements[i]);
            }
        }

        if (other.gameObject.Equals(IgnitionElement))
        {
            if(readyToUnlock /*&& LockElement.GetComponent<CellDoorScript>().IsReadyToBeUnlocked()*/)
            {
                //BEGIN EXPLOSION SEQUENCE
                GetComponent<ParticleSystem>().Play();
                LockElement.GetComponent<CellDoorScript>().BeginExplosion();
            }
        }
    }

    //Add colors to gunpowder mesh to demonstrate completeness
    private void AddColorToGunpowder()
    {
        if(numKeysAdded == 1)
        {
            gunpowderMeshRenderer.material.color = Color.yellow;
            gunpowderMeshRenderer.enabled = true;
        }

        if(numKeysAdded == 2)
        {
            gunpowderMeshRenderer.material.color = Color.magenta;
        }

        if (numKeysAdded == 3)
        {
            gunpowderMeshRenderer.material.color = Color.grey;
        }
    }

    private bool CheckIfReadyToUnlock()
    {
        return (numKeysAdded == 3);
    }

    public bool IsReadyToUnlock()
    {
        return readyToUnlock;
    }
}
