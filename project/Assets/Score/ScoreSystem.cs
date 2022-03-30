using System;
using System.Collections;
using System.Collections.Generic;
using Score;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public bool ShowPoints = true;

    public bool UseTimer = false;
    public float TotalTime = 0;
    private float timer;
    
    
    private int _score = 0;

    public List<Task> tasks = new List<Task>();
    private List<Task> _finishedTasks = new List<Task>();

    public Task FinalTask;
    
    public TextMeshProUGUI scoreTitle;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI finalPointsText;
    public TextMeshProUGUI timerText;

    
    
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
        
        finalPointsText.gameObject.SetActive(false);
        if (!ShowPoints) {
            pointsText.gameObject.SetActive(false); 
        }

        timer = TotalTime;
        if (UseTimer)
        {
            timerText.gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        scoreTitle.gameObject.SetActive(true);
        if (ShowPoints) {
            pointsText.gameObject.SetActive(true); 
        }
        else
        {
            pointsText.gameObject.SetActive(false); 
        }
        finalPointsText.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Time left: " + timer.ToString("F2");
        if (UseTimer)
        {
            if (timer <= 0)
            {
                if (!FinalTask.IsComplete())
                {
                    FinalTask.FailTask();

                    foreach (var task in tasks)
                    {
                        task.gameObject.SetActive(false);
                    }
                }
            }
        }
        
        scoreTitle.text = tasks[0].taskTitle;
        
        if (tasks.Count == 0)
        {
            Debug.Log("No Tasks");
            scoreTitle.text = "No Tasks";
        }
        else if (tasks[0].IsComplete() || tasks[0].IsFailed())
        {
            addScore(tasks[0].GetPoints());
            _finishedTasks.Add(tasks[0]);
            tasks[0].gameObject.SetActive(false);
            tasks.RemoveAt(0);

            if (tasks.Count > 0)
            {
                Debug.Log(tasks[0].taskTitle);
                tasks[0].EnableTask();
            
                scoreTitle.text = tasks[0].taskTitle;
            }
            
        }

        if (FinalTask.IsComplete())
        {
            scoreTitle.gameObject.SetActive(false);
            pointsText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            finalPointsText.gameObject.SetActive(true);
            
            finalPointsText.text = "CONRATULATIONS! \nYou completed the game.\nFinal score: " + _score.ToString();
        }
        else if (FinalTask.IsFailed())
        {
            scoreTitle.gameObject.SetActive(false);
            pointsText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            finalPointsText.gameObject.SetActive(true);
            
            finalPointsText.text = "Oh no! \nYou didn't complete the game.\nFinal score: " + _score.ToString();
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
