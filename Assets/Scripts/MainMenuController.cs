using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public InputField input;
    public GameObject Keyboard;
    public GameObject Dropdown;
    
    private void Awake()
    {
        Keyboard.SetActive(false);
        Dropdown.SetActive(false);
    }

    public void ToggleKeyboard()
    {
        Keyboard.SetActive(true);
    }


    public void CreateRoom()
    {
        Keyboard.SetActive(false);
        string roomName = input.text.Trim().ToString();
        Debug.LogError(roomName);
        bool error = RoomManager.Instance.CreateRoom(roomName);
        Debug.LogError(error);
    }
}
