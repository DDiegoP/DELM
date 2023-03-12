using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Algorythm : Code
{
    public int puntos;
    public Algorythm(string a, string k, int puntos) : base(a,k)
    {
        this.puntos = puntos;
    }

    public override void Submit(Problem p)
    {
        p.SubmitAlgorythm(this);
    }
   
}
