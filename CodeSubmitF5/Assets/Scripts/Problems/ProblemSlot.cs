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
    public KeyCode Key
    {
        get { return key; }
    }

    private int id;
    public int Id
    {
        get { return id; }
    }


    private void Update()
    {
      
    }

    public void SetID(int id)
    {
        this.id = id;
    }

    public int GetId()
    {
        return id;
    }
    public void SetTask(Problem p)
    {
        ProffesorPortrait.sprite = p.GetProffessor().portrait;
        ProffessorName.text = p.GetProffessor().GetName();
        ProblemTitle.text = p.name;
        ProblemLang.text = p.AskedLanguage.GetName();
        ProblemAlgorithm.text = p.AskedAlgorythm.GetName();
        ProblemDataStructure.text = p.AskedStructure.GetName();
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
