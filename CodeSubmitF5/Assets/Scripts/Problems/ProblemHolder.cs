using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemHolder : MonoBehaviour
{
   
    private GameManager GM;

    ProblemSlot[] slots;
    int maxSlots;
    int slotsActive = 0;
    

    // Start is called before the first frame update
    void Awake()
    {
        slots = GetComponentsInChildren<ProblemSlot>(true);
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].SetID(i);
        }
        maxSlots = slots.Length;
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

        if (slot.gameObject.activeInHierarchy) return null;

        slot.gameObject.SetActive(true);
        //slot.SetTask(p);
        slotsActive++;
        return slot;
    }

    

   public bool SlotsAvailable()
    {
        return slotsActive < maxSlots;
    }

    public void DeactivateSlot(ProblemSlot s)
    {
        slots[s.GetId()].gameObject.SetActive(false);
        slotsActive--;
    }
}
