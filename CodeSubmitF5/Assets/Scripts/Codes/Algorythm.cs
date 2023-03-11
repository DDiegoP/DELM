using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Algorythm : Code
{
    public Algorythm(string a) : base(a, new char[0])
    {

    }

    public override void Submit(Problem p)
    {
        p.SubmitAlgorythm(this);
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
