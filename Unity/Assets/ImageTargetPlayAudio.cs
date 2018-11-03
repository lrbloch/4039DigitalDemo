using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetPlayAudio : MonoBehaviour, ITrackableEventHandler {

    private TrackableBehaviour mTrackableBehavior;

	// Use this for initialization
	void Start () {
        mTrackableBehavior = GetComponent<TrackableBehaviour>();
        if(mTrackableBehavior)
        {
            mTrackableBehavior.RegisterTrackableEventHandler(this);
        }
	}
	
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
            GetComponent<AudioSource>().Play();
        }
        else
        {
            // Stop audio when target is lost
            GetComponent<AudioSource>().Pause();
        }
    }
}
