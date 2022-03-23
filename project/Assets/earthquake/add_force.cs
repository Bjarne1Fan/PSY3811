using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_force : MonoBehaviour
{
    public Rigidbody ball;
    public float force_magnitude;
    public static bool force;
    public Transform direction;

    private bool started_movement;
    // Start is called before the first frame update
    void Start()
    {
        started_movement = false;
        force = false;
    }


    // Update is called once per frame
    void Update()
    {
        if ( force && !started_movement ) {
			started_movement = true;
			ball.AddForce (direction.forward*force_magnitude);
		}
    }
}

