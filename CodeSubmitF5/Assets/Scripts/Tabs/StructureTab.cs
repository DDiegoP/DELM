using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureTab : Tab
{
    StructureTab() : base('s')
    {
        codes.Add(new Structure("Set"));
        codes.Add(new Structure("Unordered_Map"));
        codes.Add(new Structure("List"));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
