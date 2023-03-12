using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : Code
{
    public int puntos;
    public string id;
    public Language(string l,string k, int puntos) : base(l, k)
    {
        this.puntos = puntos;
    }

    public override void Submit(Problem p)
    {
        p.SubmitLanguage(this);
    }
   
}
