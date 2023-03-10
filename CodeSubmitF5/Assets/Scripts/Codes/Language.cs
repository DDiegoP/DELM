using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : Code
{
    public Language(string l) : base(l, new char[0])
    {

    }

    public override void Submit(Problem p)
    {
        p.SubmitLanguage(this);
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
