using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SucessCode : MonoBehaviour
{

    public int sucessCode = 888;
    public enum InteractableItems { SpawnKey,RenderBox,Window }
    public InteractableItems MyItems;
    private GameObject targetGameObject;

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
    void Start()
    {
        targetGameObject = GameObject.FindGameObjectWithTag("SpawnKey");
        //targetGameObject.SetActive(false); //Added to test key appearance
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnteredRightCombination()
    {
        targetGameObject.SendMessage("SetObjectActive");
        //targetGameObject.SetActive(true); //Added to test key apperance
    }

    public int getSucessCode()
    {
        return sucessCode;
    }
}