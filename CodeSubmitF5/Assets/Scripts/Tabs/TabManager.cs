using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    private static TabManager instance = null;
    public static TabManager GetInstance() { return instance; }

    [SerializeField]
    private CommandsHolder commandsHolder;

    [SerializeField] GameObject codeTypeTab;
    GameObject currentTab;

    [SerializeField]
    ProblemManager problemManager;

    Tab[] activeKeys;
    private bool KeysValid = false;
    
    private bool commandMode;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(!KeysValid) activeKeys = currentTab.GetComponentsInChildren<Tab>();
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
            commandsHolder.HandleInput();
            if (commandsHolder.CommandCompleted())
            {
                DeactivateCommands();
            }
        }
    }

    public void ChangeTab(GameObject newTab)
    {
        currentTab.SetActive(false);
        currentTab = newTab;
        currentTab.SetActive(true);
        KeysValid = false;
        
    }


    public void ShowComboTab(Code c)
    {
        commandsHolder.gameObject.SetActive(true);
        commandsHolder.SetCode(c);
        commandMode = true;
    }

    public void DeactivateCommands()
    {
        commandsHolder.gameObject.SetActive(false);
        commandMode = false;
        currentTab.SetActive(false);
        currentTab = codeTypeTab;
        currentTab.SetActive(true);
    }
}
