using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ProblemSlot : MonoBehaviour
{

    [SerializeField] private Image ProffesorPortrait;
    [SerializeField] private TMP_Text ProblemTitle;
    [SerializeField] private TMP_Text ProblemLang;
    [SerializeField] private TMP_Text ProblemAlgorithm;
    [SerializeField] private TMP_Text ProblemDataStructure;

    public void SetTask(Proffessor prof, string title, string lang, string alg, string struc)
    {
        ProffesorPortrait.sprite = prof.portrait;
        ProblemTitle.text = title;
        ProblemLang.text = lang;
        ProblemAlgorithm.text = alg;
        ProblemDataStructure.text = struc;
    }
}
