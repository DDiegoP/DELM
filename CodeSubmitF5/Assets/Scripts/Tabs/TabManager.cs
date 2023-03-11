using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    private static TabManager instance = null;
    public static TabManager GetInstance() { return instance; }


    [SerializeField] GameObject codeTypeTab;
    GameObject currentTab;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTab(GameObject newTab)
    {
        currentTab.SetActive(false);
        currentTab = newTab;
        currentTab.SetActive(true);
    }
}
