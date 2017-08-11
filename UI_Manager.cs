using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    public List<GameObject> sites;
    public GameObject MainApplicationController;
    public Text t;
    public AudioClip _userHeightAccepted_AC;
    public AudioSource TakingPhoto_AS;

    private float start;

    // Use this for initialization
    void Start () {
            Display_SiteNr(1);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       
		if((currentDisplayedSiteNr >= 3 && currentDisplayedSiteNr <= 6) && !MainApplicationController.gameObject.GetComponent<MainApplicationController>().IsSomebody_behind_Screen())
        {
                Invoke("Display_StartSite", 2);
        }
        else
        {
            CancelInvoke("Display_StartSite");
        }

		if(currentDisplayedSiteNr == 2 && !MainApplicationController.gameObject.GetComponent<MainApplicationController>().IsSomebody_behind_Screen())
		{
			Invoke("Display_ScreenSaver", 300);

		}
		else
		{
			CancelInvoke("Display_ScreenSaver");
		}
	}


    public void OnContinueClick()
    {
        var result = t.text.Trim(' ', 'c', 'm');

        MainApplicationController.gameObject.GetComponent<MainApplicationController>()._NEW_MAX_HEIGHT_BY_USER = Convert.ToInt32(result);
        float Y = MathematicAndfunctions._GetPictureYPosition_FromPotentiometr(
                  MathematicAndfunctions._GetNewMaximumPotentiometrValue(MainApplicationController.gameObject.GetComponent<MainApplicationController>()._NEW_MAX_HEIGHT_BY_USER),
                  MainApplicationController.gameObject.GetComponent<MainApplicationController>()._ALTITUDE);

        if (Y != 0)
        {
            MainApplicationController.gameObject.GetComponent<MainApplicationController>().rentgen_Ph.transform.position = new Vector3(97, Y, 90);
        }

       StartCoroutine(Display_XRayPhoto_With_AudioEffect());

    }

    
     /// <summary>
     /// Playing Audio Height.mp3 and displaying X-Ray after couple sec.
     /// </summary>
     /// <returns></returns>
     IEnumerator Display_XRayPhoto_With_AudioEffect()
    {
       TakingPhoto_AS.PlayOneShot(_userHeightAccepted_AC, 0.7f);
            yield return new WaitForSeconds(_userHeightAccepted_AC.length / 4);
        Display_SiteNr(6);
    }

    //Display Sites
    public int currentDisplayedSiteNr;
    bool buttonActivity;

    public void Display_StartSite()
    {
        Display_SiteNr(2);
    }

	public void Display_ScreenSaver(){
		Display_SiteNr (1);
	}

    public void Display_SiteNr(int siteNr)
    {

        for (int i = 0; i < sites.Count; i++)
        {
            if (siteNr - 1 == i)
            {
                sites[i].SetActive(true);
                currentDisplayedSiteNr = sites[i].GetComponent<SiteTextManager>().siteNr;
            }
            else
            {
                sites[i].SetActive(false);
            }
        }

    }

}
