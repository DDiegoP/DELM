using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgorythmTabUpdater : MonoBehaviour
{
    private List<Algorythm> unlockedAlgorythms;
    [SerializeField] private GameObject tabPrefab;
    [SerializeField]
    TabManager tabManager;

    // Start is called before the first frame update
    void Start()
    {
        unlockedAlgorythms = GameManager.GetInstance().GetUnlockedAlgorythms();

        foreach (Algorythm a in unlockedAlgorythms)
        {
            GameObject go = Instantiate(tabPrefab);
            Tab tab = go.GetComponent<Tab>();
            tab.SetOnKeyPressed(() => {
                tabManager.ShowComboTab(a);
            });
            tab.SetKey(a.GetKey());
            tab.SetTabName(a.GetName());
            go.transform.SetParent(this.transform, false);
        }

    }
}
