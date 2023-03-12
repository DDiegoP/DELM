using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum VisualMode
{
    Language,
    Structure,
    Algorythm,
    Submit
}

public class TabManager : MonoBehaviour
{
    

    private VisualMode mMode;
    private static TabManager instance = null;
    public static TabManager GetInstance() { return instance; }

    [SerializeField]
    private CommandsHolder commandsHolder;

    [SerializeField] GameObject codeTypeTab;
    GameObject currentTab;

    [SerializeField]
    ProblemManager problemManager;

    [SerializeField]
    private GameObject[] Tabs = new GameObject[3];
    

    Language currentLanguage;
    Structure currentStructure;
    Algorythm currentAlgorythm;

    Tab[] activeKeys;
    private bool KeysValid = false;

    private bool commandMode = false;

    [SerializeField]
    GameObject VSCanvas;

    [SerializeField]
    GameObject ReturnCommands;

    [SerializeField]
    GameObject SubmitCommad;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTab = codeTypeTab;
        currentTab.SetActive(true);
        commandMode = false;
        activeKeys = currentTab.GetComponentsInChildren<Tab>();
        KeysValid = true;
        mMode = VisualMode.Language;
        SubmitCommad.SetActive(false);
        ReturnCommands.SetActive(false);
    }

    public void ResetVisual(Problem p)
    {
        foreach(GameObject t in Tabs)
        {
            t.SetActive(false);
        }
        commandsHolder.ResetCommands();
        Tabs[0].SetActive(true);
        currentTab = codeTypeTab;
        currentTab.SetActive(true);
        commandMode = false;
        activeKeys = currentTab.GetComponentsInChildren<Tab>();
        KeysValid = true;
        mMode = VisualMode.Language;
        SubmitCommad.SetActive(false);
        ReturnCommands.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!VSCanvas.gameObject.activeInHierarchy) return;
        if (!KeysValid) activeKeys = currentTab.GetComponentsInChildren<Tab>();
        if (!commandMode)
        {
            //currentTab.GetComponent<Tab>().HanleInput();
            if (activeKeys == null) return;
            foreach (Tab t in activeKeys)
            {
                t.HandleInput();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                commandMode= false;
                commandsHolder.ResetCommands();
                commandsHolder.gameObject.SetActive(false);
                ReturnCommands.gameObject.SetActive(false);
                return;
            }
            commandsHolder.HandleInput();
            if (commandsHolder.CommandCompleted())
            {
                switch (mMode)
                {
                    case VisualMode.Language:
                        problemManager.SubmitCode(currentLanguage);
                        Tabs[0].SetActive(false);
                        Tabs[1].SetActive(true);
                        mMode = VisualMode.Algorythm;
                        break;
                    case VisualMode.Structure:
                        problemManager.SubmitCode(currentStructure);
                        Tabs[2].SetActive(false);
                        mMode = VisualMode.Submit;
                        SubmitCommad.SetActive(true);
                        break;
                    case VisualMode.Algorythm:
                        problemManager.SubmitCode(currentAlgorythm);
                        Tabs[1].SetActive(false);
                        Tabs[2].SetActive(true);
                        mMode = VisualMode.Structure;
                        break;
                    default:
                        break;
                }
                DeactivateCommands();
            }
        }

        if(mMode == VisualMode.Submit)
        {
            if(Input.GetKeyDown(KeyCode.F5)){
                problemManager.CloseVisual();
                problemManager.SubmitProblem();
            }
        }
    }

    public void SetMode(VisualMode mode)
    {
        mMode = mode;
    }
    public void ChangeTab(GameObject newTab)
    {
        currentTab.SetActive(false);
        currentTab = newTab;
        currentTab.SetActive(true);
        KeysValid = false;

    }


    public void ShowComboTab(Language c)
    {
        ReturnCommands.SetActive(true);
        commandsHolder.gameObject.SetActive(true);
        //SetMode(VisualMode.Language);
        commandsHolder.SetCode(c);
        currentLanguage= c;
        commandMode = true;
    }

    public void ShowComboTab(Algorythm c)
    {
        ReturnCommands.SetActive(true);
        commandsHolder.gameObject.SetActive(true);
        commandsHolder.SetCode(c);
        //SetMode(VisualMode.Algorythm);
        currentAlgorythm = c;
        commandMode = true;
    }

    public void ShowComboTab(Structure c)
    {
        ReturnCommands.SetActive(true);
        commandsHolder.gameObject.SetActive(true);
        //SetMode(VisualMode.Structure);
        commandsHolder.SetCode(c);
        currentStructure = c;
        commandMode = true;
    }

    public void DeactivateCommands()
    {
        commandsHolder.gameObject.SetActive(false);
        commandMode = false;
        currentTab.SetActive(false);
        currentTab = codeTypeTab;
        currentTab.SetActive(true);
        ReturnCommands.SetActive(false);
    }
}
