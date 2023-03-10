using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageTab : Tab
{
    LanguageTab() : base('l')
    {
        codes.Add(new Language("C++"));
        codes.Add(new Language("JS"));
        codes.Add(new Language("C#"));
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
