using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;


public class ProblemManager : MonoBehaviour
{



    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private TMP_Text score;

    [SerializeField]
    private GameObject HealthBar;

    [SerializeField]
    private ProblemHolder holder;

    [SerializeField]
    Problem[] Problems = new Problem[4];

    [SerializeField]
    CalificationTable cTable;

    [SerializeField]
    float MinGenerationTime;


    [SerializeField]
    float MaxGenerationTime;

    [SerializeField]
    float minProblemTime = 30;


    [SerializeField]
    float maxProblemTime = 60;

    GameManager gm;

    List<Proffessor> proffessors;
    List<Algorythm> algorithms;
    List<Structure> structures;
    List<Language> languages;

    float GenerationTimer = 0;
    float NextGeneration = 0;

    int activePrograms = 0;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        proffessors = gm.GetUnlockedProfessors();
        algorithms = gm.GetUnlockedAlgorythms();
        structures = gm.GetUnlockedStructures();
        languages = gm.GetUnlockedLanguages();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Problem p in Problems)
        {
            if (p.gameObject.activeInHierarchy && p.IsTimedOut())
            {
                SolveProblem(p, Calification.Time_Limit);
                this.TakeDamage(50);
            }
        }
        if (activePrograms >= Problems.Length) return;
        if(GenerationTimer >= NextGeneration)
        {
            GenerateProblem(GetFirstAvailableProblem());
            GenerationTimer = 0;
            NextGeneration = Random.Range(MinGenerationTime, MaxGenerationTime);
        }
        else
        {
            GenerationTimer += Time.deltaTime;
        }
    }

    private void GenerateProblem(Problem p)
    {
        if (!holder.SlotsAvailable()) return;
        if(p == null) return;

        
        Language l = this.languages[Random.Range(0,this.languages.Count)];
        Algorythm a = this.algorithms[Random.Range(0, this.algorithms.Count)];
        Structure s = this.structures[Random.Range(0, this.structures.Count)];
        Proffessor pr = this.proffessors[Random.Range(0,this.proffessors.Count)];
        p.SetSlot(holder.GetFirstAvailableSlot());
        p.Set(pr, l, a, s, Random.Range(minProblemTime, maxProblemTime));
        p.gameObject.SetActive(true);
        ++activePrograms;
    }

    private Problem GetFirstAvailableProblem()
    {
        int i = 1;
        Problem p = Problems[0];
        while(i < Problems.Length && p.gameObject.activeInHierarchy)
        {
            p = Problems[i];
            i++;
        }

        if (i > Problems.Length) return null;
        return p;
    }

    public void SolveProblem(Problem p, Calification cal)
    {
        cTable.CreateEntry(p.GetProffessor().GetName(), p.name, cal);
        p.gameObject.SetActive(false);
        holder.DeactivateSlot(p.GetSlot());
        if(cal == Calification.Correct) this.AddScore((int)cal);
        activePrograms--;
    }


    private void TakeDamage(int damage){
        if(HealthBar == null) return;
        HealthBar.GetComponent<HealthScript>().TakeDamage(damage);
        if(HealthBar.GetComponent<HealthScript>().curHealth <= 0){
            Instantiate(this.gameOver, this.canvas.transform);
            Time.timeScale = 0;
        }
    }

    private void AddScore(int score){
        if (this.score == null) return;
        this.score.GetComponent<ScoreScript>().AddScore(score);
    }
}
