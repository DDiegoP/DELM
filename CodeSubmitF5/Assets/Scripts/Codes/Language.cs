using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : Code
{
    public string language;
    public Language(string l)
    {
        language = l;
    }

    public override void use(Problem p)
    {
        p.applyLang(this);
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
