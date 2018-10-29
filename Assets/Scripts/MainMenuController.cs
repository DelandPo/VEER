using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public InputField input;
    public GameObject Keyboard;
    public GameObject DropdownParent;
    private Dropdown RealDropdown;
    public GameObject EditButton;
    public GameObject DeleteButton;
    private string selectedRoom;
    private void Awake()
    {
        Keyboard.SetActive(false);
        RealDropdown = DropdownParent.GetComponent<Dropdown>();
        RealDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(RealDropdown);
        });
        PopulateDropdowns();
        DropdownParent.SetActive(false);
        DeleteButton.SetActive(false);
        EditButton.SetActive(false);
    }

    public void ToggleKeyboard()
    {
        Keyboard.SetActive(true);
    }

    public void ToggleDropdown()
    {
        DropdownParent.SetActive(true);
        PopulateDropdowns();
    }

    public void EditRoom()
    {
        ToggleDropdown();
        EditButton.SetActive(true);
    }
    public void DeleteRoom()
    {
        ToggleDropdown();
        DeleteButton.SetActive(true);
    }

    public void DeleteSelectedRoom()
    {
        RoomManager.Instance.DeleteRoom(selectedRoom);
        DeleteButton.SetActive(false);

    }

    void DropdownValueChanged(Dropdown change)
    {

        selectedRoom = RoomManager.Instance.GetAllRooms("Scenes")[change.value];


    }

    public void PopulateDropdowns()
    {
        RealDropdown.ClearOptions();
        RealDropdown.AddOptions(RoomManager.Instance.GetAllRooms("Scenes"));
    }

    public void CreateRoom()
    {
        Keyboard.SetActive(false);
        string roomName = input.text.Trim().ToString();
        RoomManager.Instance.CreateRoom(roomName);
    }
}
