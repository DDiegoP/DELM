using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Command
{
    public string key;
    public string name;

    public static bool operator ==(Command lhs, Command rhs)
    {
        return lhs.Equals(rhs);
    } 

    public static bool operator !=(Command lhs, Command rhs)
    {
        return !lhs.Equals(rhs);
    }

    public bool Equals(Command obj)
    {
        return obj.name == this.name;
    }
}
public class Code 
{
    
    [SerializeField]
    protected string codeName;

    [SerializeField]
    protected Command[] commands;

    public bool unlocked;

    protected KeyCode key;

    public Code(string n, string k)
    {
        codeName = n;
        key = (KeyCode)System.Enum.Parse(typeof(KeyCode), k);
    }
    public virtual void Submit(Problem p)
    {

    }
   

    public string GetName()
    {
        return codeName;
    }

    public Command[] GetCommands()
    {
        return commands;
    }

    public void SetCommands(Command[] commands)
    {
        this.commands = commands;
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
