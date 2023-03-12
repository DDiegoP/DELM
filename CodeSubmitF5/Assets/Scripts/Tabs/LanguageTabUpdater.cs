using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageTabUpdater : MonoBehaviour
{
    private List<Language> unlockedLanguages;
    [SerializeField] private GameObject tabPrefab;
    [SerializeField]
    TabManager tabManager;
    // Start is called before the first frame update
    void Start()
    {
        unlockedLanguages = GameManager.GetInstance().GetUnlockedLanguages();

        foreach(Language l in unlockedLanguages) {
            GameObject go = Instantiate(tabPrefab);
            Tab tab = go.GetComponent<Tab>();
            tab.SetOnKeyPressed(() => {
                
                tabManager.ShowComboTab(l);
                
            });
            tab.SetKey(l.GetKey());
            tab.SetTabName(l.GetName());
            go.transform.SetParent(this.transform, false);
        }

    }
}
