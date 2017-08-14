using UnityEngine;

public class MovingStrek : MonoBehaviour {
    Animation anim;
    public float speed;

	void Start(){
        anim = gameObject.GetComponent<Animation>();
        anim.Play("movingLine");
        anim["movingLine"].speed = speed;
    }

    private void Update()
    {
        if(gameObject.activeInHierarchy && !gameObject.GetComponent<Animation>().IsPlaying("movingLine"))
        {
            anim.Play("movingLine");
            anim["movingLine"].speed = speed;
        }
    }
}
