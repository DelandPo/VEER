using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class ColoredButtonsInput : MonoBehaviour
{

    // Use this for initialization
    Queue<char> colorQueue = new Queue<char>();
    public char[] currentColorSequence = new char[4];
    public char[] sucessSequence = new char[4];
    private bool firstCharacter = true;
    GameObject Radio;

    void Start()
    {
        Radio = GameObject.Find("Radio");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterColor(char c)
    {
        
        if (colorQueue.Count == 4)
        {
            colorQueue.Dequeue();
        }

        colorQueue.Enqueue(c);

        CheckResult();

    }

    public void CheckResult()
    {
        currentColorSequence = colorQueue.ToArray();

        if (currentColorSequence.SequenceEqual(sucessSequence))
        {
            //Correct sequence entered
            //Play music
            Radio.GetComponent<AudioSource>().Play();
        }
    }

    public void EnterRed()
    {
        EnterColor('r');
    }

    public void EnterOrange()
    {
        EnterColor('o');
    }
    public void EnterYellow()
    {
        EnterColor('y');
    }
    public void EnterGreen()
    {
        EnterColor('g');
    }

}
