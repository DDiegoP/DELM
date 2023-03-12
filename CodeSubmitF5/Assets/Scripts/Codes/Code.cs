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
        if ((object)c1 == null) return (object)c2 == null;
        if ((object)c2 == null) return (object)c1 == null;
        return c1.Equals(c2);
    }
    public static bool operator !=(Code c1, Code c2)
    {
        return !c1.Equals(c2); ;
    }

    public override bool Equals(object obj) {
        return ReferenceEquals(obj, this); 
    }

    public  bool Equals(Code obj)
    {
        return this.codeName == obj.codeName;
    }
}
