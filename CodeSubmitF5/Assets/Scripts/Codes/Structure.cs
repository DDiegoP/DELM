using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : Code
{
    public string structure;
    public Structure(string s)
    {
        structure = s;
    }

    public override void use(Problem p)
    {
        p.applyStruct(this);
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
