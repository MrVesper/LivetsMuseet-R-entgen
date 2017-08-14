using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSaver_Text_AnimationController : MonoBehaviour {

    Animation animation;
    public AnimationClip animClip; 
    
	// Use this for initialization
	void Start () {
        animation = gameObject.GetComponent<Animation>();   
    }

    private void Update()
    {
        if (!animation.isPlaying)
        {
            animation.Play(animClip.name);
            animation[animClip.name].speed = 0.015f;
        }
    }

}
