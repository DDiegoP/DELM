using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Algorythm : Code
{
    public Algorythm(string a) : base(a)
    {

    }

    public override void Submit(Problem p)
    {
        p.SubmitAlgorythm(this);
    }
   
}
