using UnityEngine;

public class PulsingButtonAnimController : MonoBehaviour {

    Animation anim;
    public AnimationClip clip;
    public float speed;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim.Play(clip.name);
        anim[clip.name].speed = speed;
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy && !gameObject.GetComponent<Animation>().IsPlaying(clip.name))
        {
            anim.Play(clip.name);
            anim[clip.name].speed = speed;
        }


    }
}
