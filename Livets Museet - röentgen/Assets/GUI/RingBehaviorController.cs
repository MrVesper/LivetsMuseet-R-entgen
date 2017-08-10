using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBehaviorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.name.Equals("Left Ring"))
        {
            this.gameObject.transform.Rotate(new Vector3(0,0,-25*Time.deltaTime));
        }
        else if (this.gameObject.name.Equals("Right Ring"))
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, -30 * Time.deltaTime));
        }
        else if (this.gameObject.name.Equals("Main Ring"))
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, 30 * Time.deltaTime));
        }
        else if (this.gameObject.name.Equals("Striped ring"))
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, -5 * Time.deltaTime));
        }
    }
}
