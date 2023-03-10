using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorythm : Code
{
    public string algorythm;
    public Algorythm(string a) : base()
    {
        algorythm = a;
    }

    public override void use(Problem p)
    {
        p.applyAlg(this);
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
