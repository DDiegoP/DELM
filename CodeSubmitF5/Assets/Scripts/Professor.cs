using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

[System.Serializable]
public class Proffessor
{
    [SerializeField]
    private string name;
    public string portraitPath;
    public Task[] AllTasks;
    public Sprite portrait;
    public bool unlocked;
    List<Task> availableTasks = new List<Task>();
    
    public List<Task> GetAvailableTasks() {
        availableTasks = new List<Task>();
        foreach(Task task in AllTasks)
        {
            if(task.unlocked) {
                availableTasks.Add(task);
            }
        }
        return availableTasks;
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
    

    public override bool Equals(object other){
        return ReferenceEquals(this, other);
    }


    public bool Equals(Task other)
    {
        return this == other;
    }

    public static  bool operator ==(Task left, Task right)
    {
        return left.title == right.title;
    }

    public static bool operator !=(Task left, Task right)
    {
        return !(left == right);
    }
}

