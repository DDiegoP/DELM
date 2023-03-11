using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : Code
{
    public Language(string l) : base(l, KeyCode.A)
    {

    }

    public override void Submit(Problem p)
    {
        p.SubmitLanguage(this);
    }
   
}
