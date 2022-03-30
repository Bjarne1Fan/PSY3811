using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class Task: MonoBehaviour
    {
        public int _points;
        protected bool _complete = false;
        protected bool _failed = false;
        public string taskTitle;
        public string taskDescription;

        protected virtual void Start()
        {
        }

        public bool IsComplete()
        {
            return _complete;
        }
        
        public void CompleteTask()
        {
            _complete = true;
        }

        public bool IsFailed()
        {
            return _failed;
        }

        public void FailTask()
        {
            _failed = true;
        }

        public int GetPoints()
        {
            return _points;
        }

        public void EnableTask()
        {
            gameObject.SetActive(true);
        }
    }
}