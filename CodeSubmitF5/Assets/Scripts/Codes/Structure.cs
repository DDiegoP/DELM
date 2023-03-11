using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Structure : Code
{
    public Structure(string s) : base(s, KeyCode.F)
    {
        
    }

    public override void Submit(Problem p)
    {
        p.SubmitStructure(this);
    }
    
}
