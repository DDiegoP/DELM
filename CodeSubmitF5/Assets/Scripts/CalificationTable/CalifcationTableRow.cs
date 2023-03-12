using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public enum Calification
{
    Correct,
    Wrong_Answer,
    Pending,
    Time_Limit
}

public class CalifcationTableRow : MonoBehaviour
{
    [SerializeField]
    GameObject correctSound, wrongSound;
   
    [SerializeField]
    TMP_Text ProffesorText;

    [SerializeField]
    TMP_Text TaskText;

    [SerializeField]
    TMP_Text CalifText;

    Calification _calif;
    string _proffessor;
    string _task;
    
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
                CalifText.color = new Color(0, 100, 0);
                correctSound.SetActive(true);
                break;
            case Calification.Wrong_Answer:
                CalifText.text = "WRONG ANSWER";
                CalifText.color = new Color(100, 0, 0);
                wrongSound.SetActive(true);
                break;
            case Calification.Time_Limit:
                CalifText.text = "TIME_LIMIT";
                CalifText.color = new Color(100, 0, 0);
                wrongSound.SetActive(true);
                break;
            case Calification.Pending:
                CalifText.text = "PENDING";
                CalifText.color = Color.blue;
                break;
            default:
                break;
        }
    }
}
