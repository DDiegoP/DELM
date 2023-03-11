using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Proffessor
{
    [SerializeField]
    private string name;
    public string portraitPath;
    public Task[] AllTasks;
    public Sprite portrait;

    public List<string> GetAvailableTasks() {
        List<string> tasks = new List<string>();
        foreach(Task task in AllTasks)
        {
            if(task.unlocked) {
                tasks.Add(task.title);
            }
        }
        return tasks;
    }

    public void LoadSprite()
    {
         portrait = Resources.Load<Sprite>(portraitPath);
    }

    public string GetName()
    {
        return name;
    }
}

[System.Serializable]
public class ProffessorHolder
{
    public Proffessor[] array;
}


[System.Serializable]
public class Task
{
    public string title;
    public bool unlocked;
}

