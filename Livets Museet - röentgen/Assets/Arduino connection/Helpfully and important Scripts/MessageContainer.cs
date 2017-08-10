using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageContainer : MonoBehaviour {

    #region PORT_CONN_MESS
        
    public static string _SUCCESS_MESSAGE = "Succesfully connected with device. \n PORT status: CONNECTED";
    public static string _FAIL_MESSAGE = "Unsuccesfully connected with device. \n PORT status: UNCONNECTED";
    public static string _CONNECTION_ENDED_ERR = "ERROR: Connection to Arduino has been closed.";

    #endregion

    #region SENSORS_VARIABLES_MESSAGE

    public static string _ALTITUDE_EMPTY_MSG = "Altitude: Waiting for data";
    public static string _DISTANCE_EMPTY_MSG = "Distance: Waiting for data";

    #endregion
}
