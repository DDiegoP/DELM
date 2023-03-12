using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandsHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject commandPrefab;
    Code code;
    string commandString;
    int actualKey = 0;
    Command[] commands;
    public void SetCode(Code c)
    {
        commandString = "";
        int child = transform.childCount;
        for(int i = 0; i < child;i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        this.code = c;
        foreach(Command cm in c.GetCommands())
        {
            GameObject GO = Instantiate(commandPrefab, this.transform);
            GO.GetComponent<CommandController>().SetCommand(cm);
            commandString += cm.key;
        }
        Debug.Log(commandString);
        actualKey = 0;
        commands = code.GetCommands();
    }
    public void HandleInput()
    {
        string input = Input.inputString;
        if(input!="") Debug.Log(input);
        foreach(char c in input)
        {
            if(c == commands[actualKey].key[0])
            {
                actualKey++;
                if (actualKey >= commands.Length) return;
            }
            else
            {
                Debug.Log("Fallo");
            }
        }
       
    }
     public bool CommandCompleted()
    {
        return actualKey>=commands.Length;
    }
}
