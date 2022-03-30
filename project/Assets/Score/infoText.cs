using TMPro;
using UnityEngine;

namespace Score
{
    public class infoText : MonoBehaviour
    {
        public float timeToAppear = 0;
        private bool _textActivated = false;
        public TextMeshPro textObject;
        public float proximity = 10;
    
        // Start is called before the first frame update
        void Start()
        {
            if (timeToAppear > 0)
            {
                textObject.gameObject.SetActive(false);
                _textActivated = false;
                Debug.Log("Text hidden");
            }
            else
            {
                _textActivated = true;
            }
        
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(timeToAppear);
            if (!_textActivated)
            {
                timeToAppear -= Time.deltaTime;
                if (timeToAppear <= 0)
                {
                    textObject.gameObject.SetActive(true);
                    _textActivated = true;
                    Debug.Log("Text appear");
                }
            
            }
        
        
            var playerObject = GameObject.FindWithTag("Player");
            var transform1 = transform;
            var dir = playerObject.transform.position - transform1.position;
            float distance = dir.magnitude;
            dir.y = 0;
            dir = dir.normalized;
            transform1.forward = -dir;

            //Debug.Log("text distance: " + distance);
            if (distance < proximity)
            {
                textObject.gameObject.SetActive(true);
            }
            else
            {
                textObject.gameObject.SetActive(false);
            }
        }
    }
}
