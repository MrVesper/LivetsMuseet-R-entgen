using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SiteBehav : MonoBehaviour {

    public GameObject SiteButton;
    public GameObject SiteManager;

    private void Start()
    {
        SiteButton = gameObject.transform.Find("Button").gameObject;
    }

    // Update is called once per frame
    void Update () {
        if ((SiteManager.gameObject.GetComponent<UI_Manager>().currentDisplayedSiteNr >= 2 && SiteManager.gameObject.GetComponent<UI_Manager>().currentDisplayedSiteNr <= 5)
            && SiteManager.gameObject.GetComponent<UI_Manager>().MainApplicationController.gameObject.GetComponent<MainApplicationController>().IsSomebody_behind_Screen())
        {
            SiteButton.SetActive(true);
        }
        else
        {
            SiteButton.SetActive(false);
        }
    }
}
