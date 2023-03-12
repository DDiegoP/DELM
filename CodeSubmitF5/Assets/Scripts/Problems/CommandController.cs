using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommandController : MonoBehaviour
{
    Command c;

    [SerializeField]
    TMP_Text text;

    [SerializeField]
    TMP_Text Key;

    public void SetCommand(Command command)
    {
        c = command;    
        text.text = command.name;
        Key.text = command.key.ToUpper();
    }
}
