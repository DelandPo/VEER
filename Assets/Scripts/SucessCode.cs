using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SucessCode : MonoBehaviour {




    public int sucessCode = 888;
    public enum InteractableItems {Door, Window,Lock }
    public InteractableItems MyItems;

    private static SucessCode _instance;
    public static SucessCode Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
        //   Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getSucessCode()
    {
        return sucessCode;
    }
}
