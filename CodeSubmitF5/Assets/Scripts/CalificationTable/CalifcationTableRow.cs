using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalifcationTableRow : MonoBehaviour
{

    public enum Calification{
        Correct,
        Wrong_Answer
    }
    [SerializeField]
    TMP_Text ProffesorText;

    [SerializeField]
    TMP_Text TaskText;

    [SerializeField]
    TMP_Text CalifText;

    Calification _calif;
    string _proffessor;
    string _task;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetParameters(string task, string proffessor, Calification calif)
    {
        _task = task;
        _proffessor = proffessor;
        _calif = calif;

        ProffesorText.text = _proffessor;
        TaskText.text = _task;
        switch (_calif)
        {

            case Calification.Correct:
                CalifText.text = "CORRECT";
                break;
            case Calification.Wrong_Answer:
                CalifText.text = "WRONG ANSWER";
                break;
            default:
                break;

        }       
    }
}
