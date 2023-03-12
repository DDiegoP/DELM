using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class KeyEvent : UnityEvent
{
}

public class Tab : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private string tabName;
    [SerializeField] private KeyEvent onKeyPressedEvent = null;
    public delegate void CallBack();
    private CallBack onKeyPressedCallBack;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = this.tabName;
        string k = this.key.ToString();
        if (k != "F5" && k[k.Length - 1] >= '0' && k[k.Length - 1] <= '9') k = k.Substring(k.Length - 1);
        this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = k;
    }

    

    public void SetOnKeyPressed(CallBack e)
    {
        onKeyPressedCallBack = e;
    }

    public void SetKey(KeyCode k)
    {
        this.key = k;
    }

    public void SetTabName(string name)
    {
        this.tabName = name;
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(key))
        {
            if (onKeyPressedCallBack != null) onKeyPressedCallBack.Invoke();
            else onKeyPressedEvent.Invoke();

        }
    }
}
