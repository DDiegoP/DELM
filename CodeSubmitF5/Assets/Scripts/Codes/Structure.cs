using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Structure : Code
{
    public Structure(string s,string k) : base(s,k)
    {
        
    }

    public override void Submit(Problem p)
    {
        p.SubmitStructure(this);
    }
    
}
