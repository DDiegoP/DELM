using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandsHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject commandPrefab;
    Code c;
    string commandString;
    public void SetCode(Code c)
    {
        commandString = "";
        this.c = c;
        foreach(Command cm in c.GetCommands())
        {
            GameObject GO = Instantiate(commandPrefab, this.transform);
            GO.GetComponent<CommandController>().SetCommand(cm);
            commandString += cm.key;
        }
        Debug.Log(commandString);
    }

    private void Update()
    {
        string input = Input.inputString;
        Debug.Log(input);
        int i = 0;
        foreach(char c in input)
        {
            //ManageInput
        }
    }
}
