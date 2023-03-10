using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalificationTable : MonoBehaviour
{
    [SerializeField]
    GameObject RowPrefab;

    float timer = 3.0f;


    private void Update()
    {
        if(timer >= 3.0f)
        {
            CreateEntry("Cleon", "HITO 1", Calification.Correct);
            timer = 0.0f;
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
    }

    
}
