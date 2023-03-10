using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour
{
    private string name;
    private char[] commands;

    public Code(string n, char[] comms)
    {
        name = n;
        commands = comms;
    }
    public virtual void Submit(Problem p)
    {

    }
    public void AddCommand(char c)
    {
        //instructions.Add(inst);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool operator ==(Code c1, Code c2)
    {
        return c1.name == c2.name;
    }
    public static bool operator !=(Code c1, Code c2)
    {
        return !(c1.name == c2.name);
    }
}
