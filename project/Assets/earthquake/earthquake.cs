using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CameraShake;
using static GlobalTimer;


public class earthquake : MonoBehaviour
{   

    public bool earthquake_activated;

    //start camera shake
    
    private float duration;
    private float intensity;
    private int earthquacke_delay;
    private int afterquacke_delay;
    private bool afterquake_activated = false;
    public int afterquacke_delay_minutes;



    // Start is called before the first frame update
    void Start()
    {
        earthquake_activated = false;
        duration = 5.0f;  //typical earthquacke between 10-30s
        intensity = 0.5f; //needs further testing
        earthquacke_delay = 5;
        afterquacke_delay = 60*afterquacke_delay_minutes +  earthquacke_delay; //1 min after main quake
    }

    // Update is called once per frame
    void Update()
    {
        if(game_time > earthquacke_delay && !earthquake_activated){
             earthquake_activated = true;
            
            CameraShake.Shake(duration, intensity);
            add_force.force = true;
            //earthquake_activated = false;
        }
        if( game_time > afterquacke_delay && !afterquake_activated ) {
            Debug.Log("Afterquake activated :) ");
            afterquake_activated = true;
            
            CameraShake.Shake(duration, intensity);
        }

        //if( Input.GetKeyDown("space") && earthquake_active == false )
        //{
        //   
        //}
    }
}
