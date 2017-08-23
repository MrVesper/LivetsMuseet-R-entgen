using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSaver : MonoBehaviour {
    // Update is called once per frame

    public GameObject MainApplicationController;
    public GameObject UI_M;

	void Update () {
		if(MainApplicationController.GetComponent<MainApplicationController>().IsScreenMoving || MainApplicationController.GetComponent<MainApplicationController>().behidnScreen)
        {
            UI_M.GetComponent<UI_Manager>().Display_SiteNr(1);
        }
	}
}
