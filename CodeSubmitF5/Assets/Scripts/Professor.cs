using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Proffessor
{
    public string name;
    public string portraitPath;
    public Task[] allTasks;
    public Sprite portrait;
    public string[] languages;

    public List<string> GetAvailableTasks() {
        List<string> tasks = new List<string>();
        foreach(Task task in allTasks)
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

