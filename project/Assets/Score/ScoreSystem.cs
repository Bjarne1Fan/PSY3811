using System;
using System.Collections;
using System.Collections.Generic;
using Score;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private int _score = 0;

    public List<Task> tasks = new List<Task>();
    private List<Task> _finishedTasks = new List<Task>();

    public Task FinalTask;

    public TextMeshProUGUI scoreTitle;
    public TextMeshProUGUI pointsText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        pointsText.text = "Points: " + _score.ToString();

        foreach (var task in tasks)
        {
            task.gameObject.SetActive(false);
        }
        
        tasks[0].gameObject.SetActive(true);
        tasks[0].EnableTask();
        scoreTitle.text = tasks[0].taskTitle;
        Debug.Log(tasks[0].taskTitle);
    }

    // Update is called once per frame
    void Update()
    {
        if (tasks.Count == 0)
        {
            Debug.Log("No Tasks");
            scoreTitle.text = "No Tasks";
        }
        else if (tasks[0].IsComplete())
        {
            addScore(tasks[0].GetPoints());
            _finishedTasks.Add(tasks[0]);
            tasks[0].gameObject.SetActive(false);
            tasks.RemoveAt(0);
            Debug.Log(tasks[0].taskTitle);
            tasks[0].EnableTask();
            
            scoreTitle.text = tasks[0].taskTitle;
        }
    }

    public int GetScore()
    {
        return _score;
    }

    public void addScore(int points)
    {
        _score += points;
        pointsText.text = "Points: " + _score.ToString();
    }
}
