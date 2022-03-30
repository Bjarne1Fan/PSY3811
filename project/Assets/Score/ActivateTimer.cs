using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class ActivateTimer : MonoBehaviour
    {
        public float timer = 0;
        private float _timeToActivate;
        private bool _activated = false;

        public List<GameObject> objectsToActivate;

        // Start is called before the first frame update
        void Start()
        {
            _timeToActivate = timer;
            foreach (var iGameObject in objectsToActivate)
            {
                iGameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!_activated)
            {
                _timeToActivate -= Time.deltaTime;

                if (_timeToActivate < 0)
                {
                    foreach (var iGameObject in objectsToActivate)
                    {
                        iGameObject.SetActive(true);
                    }

                    _activated = true;
                    Debug.Log("Activated Objects after " + timer + " seconds");
                }
            }
        }
    }
}
