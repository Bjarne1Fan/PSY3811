using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class GoalTask : Task
    {
        public ParticleSystem reachedParticles;

        
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                CompleteTask();
                Debug.Log("Reached " + taskTitle);

                Instantiate(reachedParticles, this.transform.position, Quaternion.Euler(-90f, 0f, 0f));
            }
        }
    }
}