
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraShake : MonoBehaviour {

	public static CameraShake instance;

	private Vector3 _originalPos;
	private float _timeAtCurrentFrame;
	private float _timeAtLastFrame;
	private float _fakeDelta;
	public AudioSource audio_source;
    public AudioClip audio_clip;

	void Awake()
	{
    	instance = this;
	}

	void Update() {
    // Calculate a fake delta time, so we can Shake while game is paused.
    	_timeAtCurrentFrame = Time.realtimeSinceStartup;
    	_fakeDelta = _timeAtCurrentFrame - _timeAtLastFrame;
    	_timeAtLastFrame = _timeAtCurrentFrame; 
	}

	public static void Shake (float duration, float amount) {
    	instance._originalPos = instance.gameObject.transform.localPosition;
    	instance.StopAllCoroutines();
    	instance.StartCoroutine(instance.cShake(duration, amount));
	}

	public IEnumerator cShake (float duration, float amount) {
    	float endTime = Time.time + duration;
		audio_source.PlayOneShot(audio_clip);

    	while (duration > 0) {
			// random shake in x,y,z
        	//transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

			// version 2: limmited shake in y (up/down)
			transform.localPosition = _originalPos + 
				new Vector3(Random.Range(-1f,1f) * amount, Random.Range(-1f,1f) * amount/4, Random.Range(-1f,1f)*amount);

        	duration -= _fakeDelta;

        	yield return null;
    	}
		audio_source.Stop();
    	transform.localPosition = _originalPos;
	}
}
