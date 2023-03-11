using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Code 
{
    
    [SerializeField]
    protected string codeName;
    
    [SerializeField]
    protected List<char> commands;

    public Code(string n)
    {
        codeName = n;
        commands = new List<char>();
    }
    public virtual void Submit(Problem p)
    {

    }
    public void AddCommand(char c)
    {
        //instructions.Add(inst)
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
    

    public static bool operator ==(Code c1, Code c2)
    {
        return c1.codeName == c2.codeName;
    }
    public static bool operator !=(Code c1, Code c2)
    {
        return !(c1.codeName == c2.codeName);
    }
}
