using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Algorythm : Code
{
    public Algorythm(string a, string k) : base(a,k)
    {

    }

    public override void Submit(Problem p)
    {
        p.SubmitAlgorythm(this);
    }
   
}
