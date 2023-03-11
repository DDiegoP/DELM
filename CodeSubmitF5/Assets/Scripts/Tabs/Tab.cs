using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private string tabName;
    [SerializeField] GameObject tabsToOpen;

    public void Use()
    {
        TabManager.GetInstance().ChangeTab(tabsToOpen);
    }
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = this.tabName;
        string k = this.key.ToString();
        if (k != "F5" && k[k.Length - 1] >= '0' && k[k.Length - 1] <= '9') k = k.Substring(k.Length - 1);
        this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = k;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Use();
        }
    }
}
