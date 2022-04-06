using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    public List<float> delays;
    static public float game_time;

    // Start is called before the first frame update
    void Start()
    {
        game_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        game_time += Time.deltaTime;
    }
}
