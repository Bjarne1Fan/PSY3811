using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_balls : MonoBehaviour
{
    public List<Object> obj;
    public int destroy_delay;
    // Start is called before the first frame update
    void Start()
    {
        destroy_delay = 20;

        for( int i = 0; i < obj.Count; i++){
            Destroy(obj[i], destroy_delay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
