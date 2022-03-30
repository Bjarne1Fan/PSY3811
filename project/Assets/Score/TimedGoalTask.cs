using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class TimedGoalTask : GoalTask
    {
        public ParticleSystem failedParticles;
        public float taskTime = 10;
        private float _startTime;
        public bool ScoreDecreaseOverTime = false;
        private string originalTaskTitle;
        private int originalPoints;
        

        protected override void Start()
        {
            base.Start();
            originalTaskTitle = taskTitle;
            originalPoints = _points;
            _startTime = taskTime;
        }
        
        private void Update()
        {
            taskTime -= Time.deltaTime;

            if (ScoreDecreaseOverTime)
            {
                _points = (int)(originalPoints * (taskTime / _startTime));
            }
            
            string timeText = taskTime.ToString("F2");

            taskTitle = originalTaskTitle + " Time left: " + timeText;

            if (taskTime < 0)
            {
                Instantiate(failedParticles, this.transform.position, Quaternion.Euler(-90f, 0f, 0f));
                FailTask();
            }
        }
    }
}