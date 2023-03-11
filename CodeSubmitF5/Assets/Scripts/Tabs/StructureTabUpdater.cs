using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureTabUpdater : MonoBehaviour
{
    private List<Structure> unlockedStructures;
    [SerializeField] private GameObject tabPrefab;

    // Start is called before the first frame update
    void Start()
    {
        unlockedStructures = GameManager.GetInstance().GetUnlockedStructures();

        foreach (Structure s in unlockedStructures)
        {
            GameObject go = Instantiate(tabPrefab);
            Tab tab = go.GetComponent<Tab>();
            tab.SetOnKeyPressed(() => {
                GameManager.GetInstance().SubmitStructure(s);
            });
            tab.SetKey(s.GetKey());
            tab.SetTabName(s.GetName());
            go.transform.SetParent(this.transform, false);
        }

    }
}
