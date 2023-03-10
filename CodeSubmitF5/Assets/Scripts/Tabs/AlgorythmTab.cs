using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgorythmTab : Tab
{
    AlgorythmTab() : base('a')
    {
        Algorythm a = new Algorythm("Backtracking");
        //a.addInstruction();
        codes.Add(a);
        codes.Add(new Algorythm("Divide y vencer�s"));
        codes.Add(new Algorythm("Sort"));
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
