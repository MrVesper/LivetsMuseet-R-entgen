using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplayDate : MonoBehaviour {

	void Update () {
        gameObject.GetComponent<Text>().text = ("Lund den " + DateTime.Now.Date.ToString("dd ")+ getProperMonthName(DateTime.Now.Date.ToString("MMMM"))+ DateTime.Now.Date.ToString(" yyyy")+".").ToUpper();
	}

     string getProperMonthName(string month)
    {
        switch (month)
        {
            case "January": return "januari";
            case "February": return "februari";
            case "March": return "mars";
            case "April": return "april";
            case "May": return "maj";
            case "June": return "juni";
            case "July": return "juli";
            case "August": return "augusti";
            case "September": return "september";
            case "October": return "oktober";
            case "November": return "november";
            case "December": return "december";
            default: return "";
        }
    }
}
