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
    int i = 0;

    // Start is called before the first frame update
    void Awake()
    {
        slots = GetComponentsInChildren<ProblemSlot>(true);
        maxSlots = slots.Length;
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
            slot.SetTask(profs[i % profs.Length], profs[i % profs.Length].GetAvailableTasks()[0], GM.GetLanguages()[0].GetName(),
                GM.GetAlgorythms()[0].GetName(), GM.GetStructures()[0].GetName());
            slotsActive++;
            i++;
        }
    }

    public ProblemSlot GetFirstAvailableSlot()
    {
        ProblemSlot slot = slots[0];
        int i = 0;
        while (slot.gameObject.activeInHierarchy && i < slots.Length)
        {
            slot = slots[i];
            ++i;
        }
        return slot;
    }

    private void GenerateNewProblem(ProblemSlot slot)
    {
        slot.gameObject.SetActive(true);

        slot.SetTask(GM.GenerateRandomProblem());
    }
}
