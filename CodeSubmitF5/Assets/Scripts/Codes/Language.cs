using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : Code
{
    public Language(string l,string k) : base(l, k)
    {

    }

    public override void Submit(Problem p)
    {
        p.SubmitLanguage(this);
    }
   
}
