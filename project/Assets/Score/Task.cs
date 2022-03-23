using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class Task: MonoBehaviour
    {
        public int _points;
        protected bool _complete;
        public string taskTitle;
        public string taskDescription;

        private void Start()
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