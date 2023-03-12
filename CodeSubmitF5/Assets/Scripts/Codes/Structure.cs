using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Structure : Code
{

    public int puntos;

    public Structure(string s,string k, int puntos) : base(s,k)
    {
        this.puntos = puntos;
    }

    public override void Submit(Problem p)
    {
        p.SubmitStructure(this);
    }
    
}
