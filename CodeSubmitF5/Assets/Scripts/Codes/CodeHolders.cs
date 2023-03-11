using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LanguageSerializable
{
    public string name;
    public char[] commands;
}
[System.Serializable]
public class LanguageHolder
{
    public LanguageSerializable[] languages;

    public Language[] GetLanguages()
    {
        Language[] langs= new Language[languages.Length];
        for(int i = 0; i < languages.Length; i++)
        {
            langs[i] = new Language(languages[i].name);
            foreach(char c in languages[i].commands)
            {
                langs[i].AddCommand(c);
            }
        }
        return langs;
    } 
}

[System.Serializable]
public class AlgorythmHolder
{
    public Algorythm[] algorythms;
}


[System.Serializable]
public class StructureHolder
{
    public Structure[] languages;
}
