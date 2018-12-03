using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialpadInput : MonoBehaviour
{
    // Use this for initialization
    public Text code;
    public string sucessCode = "";
    private bool firstCharacter = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterCode(string number)
    {

        if (firstCharacter || code.text == "Wrong Code!!")
        {
            code.text = "";
        }
        code.text += number;
        sucessCode = code.text;
        firstCharacter = false;


    }

    public void CheckResult()
    {
        if (sucessCode == SucessCode.Instance.getSucessCode().ToString())
        {
            code.text = "Sucess!";
            Debug.Log("You entered the code sucessfully");
            SucessCode.Instance.EnteredRightCombination();
        }
        else
        {
            code.text = "Wrong Code!!";
        }
    }

    public void ClearInput()
    {
        code.text = "";
    }

    public void EnterZero()
    {
        EnterCode("0");
    }

    public void EnterOne()
    {
        EnterCode("1");
    }
    public void EnterTwo()
    {
        EnterCode("2");
    }
    public void EnterThree()
    {
        EnterCode("3");
    }
    public void EnterFour()
    {
        EnterCode("4");
    }
    public void EnterFive()
    {
        EnterCode("5");
    }
    public void EnterSix()
    {
        EnterCode("6");
    }
    public void EnterSeven()
    {
        EnterCode("7");
    }
    public void EnterEight()
    {
        EnterCode("8");
    }
    public void EnterNine()
    {
        EnterCode("9");
    }


}