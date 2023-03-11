using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class ProblemSlot : MonoBehaviour
{

    [SerializeField] private Image ProffesorPortrait;
    [SerializeField] private TMP_Text ProffessorName;
    [SerializeField] private TMP_Text ProblemTitle;
    [SerializeField] private TMP_Text ProblemLang;
    [SerializeField] private TMP_Text ProblemAlgorithm;
    [SerializeField] private TMP_Text ProblemDataStructure;
    [SerializeField] private KeyCode key;

    private KeyCode keyCode;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Debug.Log("AAAAAAAAAAA");
            
        }
    }

    public void SetTask(Problem p)
    {
        //ProffesorPortrait.sprite = prof.portrait;
        //ProffessorName.text = prof.name;
        //ProblemTitle.text = title;
        //ProblemLang.text = lang;
        //ProblemAlgorithm.text = alg;
        //ProblemDataStructure.text = struc;
    }

    public void SetTask(Proffessor prof, string title, string lang, string alg, string struc)
    {
        ProffesorPortrait.sprite = prof.portrait;
        ProffessorName.text = prof.GetName();
        ProblemTitle.text = title;
        ProblemLang.text = lang;
        ProblemAlgorithm.text = alg;
        ProblemDataStructure.text = struc;
    }
}
