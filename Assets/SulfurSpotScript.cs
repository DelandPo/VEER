using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SulfurSpotScript : MonoBehaviour
{
    public GameObject KeyElement;

    public GameObject PrizeElement;

	// Use this for initialization
	void Start ()
    {
        PrizeElement.SetActive(false);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(KeyElement))
        {
            PrizeElement.SetActive(true);
        }
    }
}
