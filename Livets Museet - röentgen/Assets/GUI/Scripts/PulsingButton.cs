using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingButton : MonoBehaviour {
    Animation animation;
    public AnimationClip animClip;
    // Use this for initialization
    void Start () {
        animation = gameObject.GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!animation.isPlaying)
        {
            animation.Play(animClip.name);
            animation[animClip.name].speed = 0.4f;
        }
    }
}
