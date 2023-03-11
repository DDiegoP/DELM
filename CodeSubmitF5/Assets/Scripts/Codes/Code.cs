using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Code 
{
    
    [SerializeField]
    protected string codeName;

    protected KeyCode key;

    [SerializeField]
    protected List<char> commands;

    public Code(string n, KeyCode k)
    {
        codeName = n;
        commands = new List<char>();
        key = k;
    }
    public virtual void Submit(Problem p)
    {

    }
    public void AddCommand(char c)
    {
        commands.Add(c);
    }

    public string GetName()
    {
        return codeName;
    }

    public char[] GetCommands()
    {
        return commands.ToArray();
    }
    
    public KeyCode GetKey()
    {
        return key;
    }

    public static bool operator ==(Code c1, Code c2)
    {
        return c1.codeName == c2.codeName;
    }
    public static bool operator !=(Code c1, Code c2)
    {
        return !(c1.codeName == c2.codeName);
    }
}
