using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Structure : Code
{
    public Structure(string s) : base(s, new char[0])
    {
        
    }

    public override void Submit(Problem p)
    {
        p.SubmitStructure(this);
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
