using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalificationTable : MonoBehaviour
{
    [SerializeField]
    GameObject RowPrefab;

    [SerializeField]
    int MaxRows = 15;

    List<GameObject> Rows = new List<GameObject>();

    static int id = 0;

    float timer = 0.5f;


    private void Update()
    {
        if(timer >= 0.5f)
        {
            //CreateEntry("Cleon", "HITO " + id, Calification.Wrong_Answer);
            timer = 0.0f;
            ++id;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void CreateEntry(string proffessoName, string taskId, Calification calif)
    {
        GameObject row = Instantiate(RowPrefab, this.transform);
        row.GetComponent<CalifcationTableRow>().SetParameters(taskId, proffessoName, calif);
        Rows.Add(row);

        if(Rows.Count > MaxRows)
        {
            GameObject firstRow = Rows[0];
            Destroy(firstRow);
            Rows.Remove(firstRow);
        }
    }

    
}
