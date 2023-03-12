using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;


public class ProblemManager : MonoBehaviour
{

    private Problem activeProblem;

    [SerializeField]
    private GameObject VSCanvas;

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

    float GenerationTimer = -2.5f;
    float NextGeneration = 0;
    float timeToPlay = 0;

    int activePrograms = 0;

    List<Problem> problemsToSubmit;
    List<float> submissionTimers;
    List<float> submissionTimersExpire;
    List<CalifcationTableRow> submittedRows;

    private void reduceTime(){
        if(this.maxProblemTime <= 2) return;
        this.maxProblemTime -= 2;
        this.minProblemTime -= 1;
    }


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        proffessors = gm.GetUnlockedProfessors();
        algorithms = gm.GetUnlockedAlgorythms();
        structures = gm.GetUnlockedStructures();
        languages = gm.GetUnlockedLanguages();
        problemsToSubmit = new List<Problem>();
        submissionTimers = new List<float>();
        submissionTimersExpire = new List<float>();
        submittedRows= new List<CalifcationTableRow>();
    }


    // Update is called once per frame
    void Update()
    {

        handleInput();

        foreach (Problem p in Problems)
        {
            if (p.gameObject.activeInHierarchy && p.IsTimedOut())
            {
                SolveProblem(p, Calification.Time_Limit);
                this.TakeDamage(20); //Daño al TimeLimit
               
            }
        }

        if (activeProblem!=null && activeProblem.IsTimedOut())
        {
            VSCanvas.SetActive(false);
        }

        for (int i = 0; i < problemsToSubmit.Count; i++)
        {
            if (submissionTimers[i] > submissionTimersExpire[i])
            {
                Problem p = problemsToSubmit[i]; //Aqui tendria que resolverlo
                
                Calification c = p.CheckCorrect() ? Calification.Correct : Calification.Wrong_Answer;
                if (c == Calification.Correct) {this.AddScore(p.GetPoints()); this.reduceTime();}
                else if(c == Calification.Wrong_Answer) this.TakeDamage(10); //Daño al equivocarse
                submittedRows[i].SetParameters(p.name, p.GetProffessor().GetName(), c);
                problemsToSubmit.RemoveAt(i);
                submissionTimers.RemoveAt(i);
                submissionTimersExpire.RemoveAt(i);
                activePrograms--;
            }
            else
            {
                submissionTimers[i] += Time.deltaTime;
            }
        }
        if (activePrograms >= Problems.Length) return;
        if (GenerationTimer >= NextGeneration)
        {
            GenerateProblem();
            GenerationTimer = 0;
            NextGeneration = Random.Range(MinGenerationTime, MaxGenerationTime);
        }
        else
        {
            GenerationTimer += Time.deltaTime;
        }
    }

    private void GenerateProblem()
    {
        if (!holder.SlotsAvailable()) return;

        ProblemSlot slot = holder.GetFirstAvailableSlot();
        Problem p = Problems[slot.Id];

        Language l = this.languages[Random.Range(0, this.languages.Count)];
        Algorythm a = this.algorithms[Random.Range(0, this.algorithms.Count)];
        Structure s = this.structures[Random.Range(0, this.structures.Count)];
        Proffessor pr = this.proffessors[Random.Range(0, this.proffessors.Count)];
        p.SetSlot(slot);
        p.Set(pr, l, a, s, Random.Range(minProblemTime, maxProblemTime));
        p.gameObject.SetActive(true);
        ++activePrograms;
    }


    private void handleInput()
    {
        if (!VSCanvas.activeInHierarchy)
        {
            foreach (ProblemSlot pS in holder.Slots)
            {
                if (pS.gameObject.activeInHierarchy)
                {
                    if (Input.GetKeyDown(pS.Key))
                    {
                        Debug.Log("Seleccionas Problema " + pS.Id.ToString());

                        //problema al problemHolder
                        activeProblem = Problems[pS.Id];

                        //abrir VSCode
                        VSCanvas.SetActive(true);
                        TabManager.GetInstance().ResetVisual(activeProblem);  
                        break;
                    }
                }
            }
        }
    }

    private Problem GetFirstAvailableProblem()
    {
        int i = 1;
        Problem p = Problems[0];
        while (i < Problems.Length && p.gameObject.activeInHierarchy)
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
        activePrograms--;
    }


    private void TakeDamage(int damage)
    {
        if (HealthBar == null) return;
        HealthBar.GetComponent<HealthScript>().TakeDamage(damage);
        if (HealthBar.GetComponent<HealthScript>().curHealth <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void AddScore(int score)
    {
        if (this.score == null) return;
        //Aqui actualizamos en general tambien
        this.gm.Credits += score;
        this.score.GetComponent<ScoreScript>().AddScore(score);
    }

    public void SubmitCode(Algorythm a)
    {
        activeProblem.SubmitAlgorythm(a);
    }
    public void SubmitCode(Language l)
    {
        activeProblem.SubmitLanguage(l);
    }
    public void SubmitCode(Structure s)
    {
        activeProblem.SubmitStructure(s);
    }

    public void SubmitProblem()
    {
        problemsToSubmit.Add(activeProblem);
        activeProblem.Disable();
        holder.DeactivateSlot(activeProblem.GetSlot());
        submissionTimers.Add(0.0f);
        submissionTimersExpire.Add(Random.Range(1,10));
        CalifcationTableRow r = cTable.CreateEntry(activeProblem.name, activeProblem.GetProffessor().GetName(), Calification.Pending);
        submittedRows.Add(r);
    }

    public void CloseVisual()
    {
        VSCanvas.SetActive(false);
    }
    public string GetSubmittedLanguageName()
    {
        if (activeProblem.GetSubmittedLanguage() == null) return "cpp";
        return activeProblem.GetSubmittedLanguage().id;
    }
}
