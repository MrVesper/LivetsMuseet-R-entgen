using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    public List<GameObject> sites;
    public GameObject MainApplicationController;
    public Text t;

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
        var result = t.text.Trim(' ','c','m');

        MainApplicationController.gameObject.GetComponent<MainApplicationController>()._NEW_MAX_HEIGHT_BY_USER = Convert.ToInt32(result);
        float Y = MathematicAndfunctions._GetPictureYPosition_FromPotentiometr(
                  MathematicAndfunctions._GetNewMaximumPotentiometrValue(MainApplicationController.gameObject.GetComponent<MainApplicationController>()._NEW_MAX_HEIGHT_BY_USER),
                  MainApplicationController.gameObject.GetComponent<MainApplicationController>()._ALTITUDE);

        if (Y != 0)
        {
            MainApplicationController.gameObject.GetComponent<MainApplicationController>().rentgen_Ph.transform.position = new Vector3(97, Y, 90);
        }
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

      /*  if (gameObject.transform.FindChild("NavArrows") != null)
        {
            if (allowLoop)
            {
                LeftArrow.SetActive(true);
                RightArrow.SetActive(true);
            }
            else
            {
                if (siteNr == sites.Count)
                {
                    LeftArrow.SetActive(true);
                    RightArrow.SetActive(false);
                }
                else if (siteNr == 1)
                {
                    LeftArrow.SetActive(false);
                    RightArrow.SetActive(true);
                }
                else if (siteNr > 1 && siteNr < sites.Count)
                {
                    LeftArrow.SetActive(true);
                    RightArrow.SetActive(true);
                }
            }
        }*/

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
          //  ChangeButtonStatus();
        }

    }

    /* public void AssignAssetsForEveryPanelSite()
     {
         foreach (GameObject site in sites)
         {
             site.GetComponent<SiteTextManager>().AssignAssetsFromResorces();
         }
     }

     //Display sites with arrows like in loop photo gallery
     public bool allowLoop = false;
     public GameObject LeftArrow; //Left arrow button
     public GameObject RightArrow;//Right arrow button

     public void Display_Sites_With_NavArrows(int iterator)
     {
         int siteIndex = currentDisplayedSiteNr - 1;//Site index in sites list

         if ((siteIndex >= 0) && (siteIndex <= sites.Count))
         {//Checking if we are in list range

             siteIndex += iterator;
             OnOFFLoopManager(iterator, ref siteIndex);


             for (int i = 0; i < sites.Count; i++)
             {
                 if (siteIndex == i)
                 {
                     sites[i].SetActive(true);
                     currentDisplayedSiteNr = sites[i].GetComponent<SiteTextManager>().siteNr;
                 }
                 else
                 {
                     sites[i].SetActive(false);
                 }
             }//End of for loop
         }
         ChangeButtonStatus();
     }

     /// <summary>
     /// void OnOFFLoopManager (int iterator, ref int siteIndex)
     /// 
     /// Managing site index and arrows dependly of loop allow or not.
     /// 
     /// </summary>
     /// <param name="iterator"></param>
     /// <param name="siteIndex"></param>
     void OnOFFLoopManager(int iterator, ref int siteIndex)
     {
         if (allowLoop)
         {
             //If allow Loop with arrow then 
             if ((siteIndex >= sites.Count) && iterator > 0)
             {
                 siteIndex = 0;
             }
             else
                 if ((siteIndex < 0) && iterator < 0)
             {
                 siteIndex = sites.Count - 1;
             }
             //end of if esle block
         }
         else
         {
             if ((siteIndex > 0) && (siteIndex < (sites.Count - 1)))
             {
                 LeftArrow.SetActive(true);
                 RightArrow.SetActive(true);
             }
             else
                 if (siteIndex == (sites.Count - 1))
             {
                 RightArrow.SetActive(false);
                 LeftArrow.SetActive(true);
                 siteIndex = sites.Count - 1;
             }
             else
                     if (siteIndex == 0)
             {
                 RightArrow.SetActive(true);
                 LeftArrow.SetActive(false);
                 siteIndex = 0;
             }
         }
     }

     void resetButtonStatusAfterClick()
     {
         buttonActivity = false;
     }

     void ChangeButtonStatus()
     {
         if (!this.gameObject.tag.Equals("test"))
         {
             buttonActivity = true;
             Invoke("resetButtonStatusAfterClick", 0.5f);
         }
     }
     */
}
