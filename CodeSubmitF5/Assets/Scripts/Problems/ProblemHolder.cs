using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemHolder : MonoBehaviour
{
    [SerializeField]
    private GameManager GM;
    ProblemSlot[] slots;
    int maxSlots;
    int slotsActive = 0;
    int actualSlot = 0;
    List<Problem> problems;

    // Start is called before the first frame update
    void Awake()
    {
        slots = GetComponentsInChildren<ProblemSlot>(true);    
        maxSlots = slots.Length;
    }

    private void Start()
    {
        GM = GameManager.GetInstance();
        problems = GM.GetProblems();
       // AssignProblems();
    }

    private void AssignProblems()
    {
        int i = 0; 
        ProblemSlot slot = GetFirstAvailableSlot();
        while(i < problems.Count && slot != null)
        {
            slots[i].SetTask(problems[i]);
            slots[i].gameObject.SetActive(true);
            slotsActive++;
            ++i;
        }

        actualSlot = i % slots.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (slotsActive >= maxSlots) return;

        ProblemSlot slot = GetFirstAvailableSlot();
        if (slot != null)
        {
            slot.gameObject.SetActive(true);
            Proffessor[] profs = GM.GetProfessors();
            slot.SetTask(profs[actualSlot % profs.Length], profs[actualSlot % profs.Length].GetAvailableTasks()[0], GM.GetLanguages()[0].GetName(),
                GM.GetAlgorythms()[0].GetName(), GM.GetStructures()[0].GetName());
            problems.Add(GenerateNewProblem(slot));
            slotsActive++;
        }
    }

    private void OnDestroy()
    {
        GM.SetProblems(problems.ToArray());
    }

    public ProblemSlot GetFirstAvailableSlot()
    {
        ProblemSlot slot = slots[0];
        int i = 0;
        while (i < slots.Length - 1 && slot.gameObject.activeInHierarchy)
        {
            ++i;
            slot = slots[i];
        }

        actualSlot = i;

        if (slot.gameObject.activeInHierarchy) return null;
        return slot;
    }

    private Problem GenerateNewProblem(ProblemSlot slot)
    {
        slot.gameObject.SetActive(true);

        Problem p = GM.GenerateRandomProblem();
        slot.SetTask(p);
        return p;
    }
}
