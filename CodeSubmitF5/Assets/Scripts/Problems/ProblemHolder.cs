using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemHolder : MonoBehaviour
{
    ProblemSlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        slots = GetComponentsInChildren<ProblemSlot>(true);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
