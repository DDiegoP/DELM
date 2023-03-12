using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandsHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject commandPrefab;

    [SerializeField]
    private Image[] algImages = new Image[3];

    [SerializeField]
    private ProblemManager problemManager;
    Code code;
    string commandString;
    int actualKey = 0;
    Command[] commands;
    private List<GameObject> commandObjects = new List<GameObject>();
    VisualMode mode;

    string[] route = new string[3];
   
    public void SetCode(Language c)
    {
        mode = VisualMode.Language;
        commandString = "";
        foreach (GameObject GO in commandObjects)
        {
            Destroy(GO);
        }

        this.code = c;
        foreach (Command cm in c.GetCommands())
        {
            GameObject GO = Instantiate(commandPrefab, this.transform);
            GO.GetComponent<CommandController>().SetCommand(cm);
            commandString += cm.key;
            commandObjects.Add(GO);
        }
        Debug.Log(commandString);
        actualKey = 0;
        commands = code.GetCommands();
    }

    public void SetCode(Structure c)
    {
        mode = VisualMode.Structure;
        commandString = "";
        foreach (GameObject GO in commandObjects)
        {
            Destroy(GO);
        }

        this.code = c;
        foreach (Command cm in c.GetCommands())
        {
            GameObject GO = Instantiate(commandPrefab, this.transform);
            GO.GetComponent<CommandController>().SetCommand(cm);
            commandString += cm.key;
            commandObjects.Add(GO);
        }
        Debug.Log(commandString);
        actualKey = 0;
        commands = code.GetCommands();

    }

    public void SetCode(Algorythm c)
    {
        mode = VisualMode.Algorythm;
        commandString = "";
        foreach (GameObject GO in commandObjects)
        {
            Destroy(GO);
        }

        this.code = c;
        foreach (Command cm in c.GetCommands())
        {
            GameObject GO = Instantiate(commandPrefab, this.transform);
            GO.GetComponent<CommandController>().SetCommand(cm);
            commandString += cm.key;
            commandObjects.Add(GO);
        }
        Debug.Log(commandString);
        actualKey = 0;
        commands = code.GetCommands();
        string langName = problemManager.GetSubmittedLanguageName();
        string algName = langName + c.GetName();
        for (int i = 0; i < route.Length; i++)
        {
            route[i] = "Textures/Codigo/" + langName + "/" +  algName + "/" + algName + "Part" + (i + 1);
        }
    }
    public void HandleInput()
    {
        string input = Input.inputString;
        foreach (char c in input)
        {
            if (c == commands[actualKey].key[0])
            {
                Destroy(commandObjects[0]);
                commandObjects.RemoveAt(0);
                if(mode == VisualMode.Algorythm)
                {
                    Sprite sprite = Resources.Load<Sprite>(route[actualKey]);
                    algImages[actualKey].sprite = Resources.Load<Sprite>(route[actualKey]);
                }
                actualKey++;
                if (actualKey >= commands.Length) return;
            }
            else
            {
                Debug.Log("Fallo");
            }
        }

    }

    public void SetMode(VisualMode mode)
    {
        this.mode = mode;
    }
    public bool CommandCompleted()
    {
        return actualKey >= commands.Length;
    }

    public void ResetCommands()
    {
        actualKey = 0;
        foreach(Image i in algImages)
        {
            i.sprite = null;
        }
    }
}
