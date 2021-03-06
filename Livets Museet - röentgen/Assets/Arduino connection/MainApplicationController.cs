﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class MainApplicationController : MonoBehaviour {

    private Thread arduinoThread;
    private static List<string> _sPorts;
    private static bool _Wait = true;

    public float _DISTANCE;
    public int _ALTITUDE;
    private static Vector3 _DELTA_ALT;
    public bool IsScreenMoving = false;
    

    public Text altitude_Txt;
    public Text distance_Txt;
    public Text photo_Y;

    public GameObject rentgen_Ph;

    public float _NEW_MAX_HEIGHT_BY_USER;
    //int last=255;
    public int altimeterReads;
    public  AudioSource _MovingScreen_AS;
    public  AudioClip _movingScreen_AC;

    private static bool _killThread;

    private void Start()
    {
         _killThread = false;

         arduinoThread = new Thread(ArduinoThreadMethod);
         arduinoThread.Name = "ArduinoThread";
         _sPorts = new List<string>(SerialPort.GetPortNames());

        _RESET_SENSORS_VARIABLE();
        StartCoroutine(TestALT());
        
    }

    IEnumerator TestALT()
    {
        int delayedAlt = _ALTITUDE;

        yield return new WaitForSeconds(0.15f);

        if (delayedAlt != _ALTITUDE && altimeterReads>1)
        {
            IsScreenMoving = true;
            if (!_MovingScreen_AS.isPlaying && _MovingScreen_AS != null)
            {
                _MovingScreen_AS.PlayOneShot(_movingScreen_AC, 0.5f);
            }
        }
        else
        {
            IsScreenMoving = false;
            _MovingScreen_AS.Stop();
        }
        StartCoroutine(TestALT());
    }

    private void _RESET_SENSORS_VARIABLE()
    {
        _NEW_MAX_HEIGHT_BY_USER = _DISTANCE  = altimeterReads = 0;
        _DELTA_ALT = Vector3.zero;
    }

    private void FixedUpdate()
    {

        #region ARDUINO_THREAD_MANAGMENT_BASED_ON_AVAILABLE_PORTS
        _sPorts = new List<string>(SerialPort.GetPortNames());
        ShouldStartNewThread();
        Start_Arduino_Thread();
        #endregion

       /* altimeterReads++;
        if (altimeterReads > 10 && !IsScreenMoving) altimeterReads = 1;
         float temp = _ALTITUDE - last;
         _DELTA_ALT = new Vector3(0.0f, temp, 0.0f);
         last = _ALTITUDE;*/

        IsSomebody_behind_Screen();

        #region READING_AND_USING_SENSORS_VARIABLE
             DisplaySensorsValue();
            TransformRentgenPhoto();
            photo_Y.text = "Photo Y: " + rentgen_Ph.transform.position.y.ToString();
        #endregion

        Debug.Log("Thread status: " + arduinoThread.ThreadState);
    }

    private void Start_Arduino_Thread()
    {
        if (arduinoThread.ThreadState.Equals(ThreadState.Unstarted) || arduinoThread.ThreadState.Equals(ThreadState.Stopped))
        {
            if (!_Wait)
            {
                _Wait = true;
                _killThread = false;
                arduinoThread = new Thread(ArduinoThreadMethod);
                arduinoThread.Name = "ArduinoThread";
                arduinoThread.Start();
            }
        }
        else
        {
            _Wait = true;
        }
    }

    private void DisplaySensorsValue()
    {
        if (_ALTITUDE <= 0 && _DISTANCE <= 0)
        {
            altitude_Txt.text = MessageContainer._ALTITUDE_EMPTY_MSG;
            distance_Txt.text = MessageContainer._DISTANCE_EMPTY_MSG;
        }
        else
        {
            altitude_Txt.text = _ALTITUDE.ToString();
            distance_Txt.text = _DISTANCE.ToString();
        }
    }

    public void TransformRentgenPhoto()
    {

        if (behidnScreen && _DELTA_ALT != Vector3.zero) 
        {
                float interval = MathematicAndfunctions.GetInterval(MathematicAndfunctions._GetNewMaximumPotentiometrValue(_NEW_MAX_HEIGHT_BY_USER));
                rentgen_Ph.transform.position += new Vector3(0, ((_DELTA_ALT.y * -1) * interval), 0);
                _DELTA_ALT = Vector3.zero;//IMPORTANT: WE HAVE TO ZEROING D_ALT AFTER IT WAS USED TO TRANSLATION
        }
    }

    private void StopPlay()
    {
        _MovingScreen_AS.Stop();
    }

    public bool behidnScreen;

    public void IsSomebody_behind_Screen()
    {
        if ((_DISTANCE >= 1 && _DISTANCE <= 75))
        {
            behidnScreen = true;
        }
        else
        {
            behidnScreen = false;
        }
    }

  public bool IsArduinoThreadRunning()
    {
        if (arduinoThread.ThreadState == ThreadState.Running) return true;
        else return false;
    }

  private void ShouldStartNewThread()
    {
        if (_sPorts.Count <= 0)
        {
           _Wait = true;
        }
        else
        {
            _Wait = false;
        }
    }


#region ARDUINO_THREAD
    private void ArduinoThreadMethod()
    {
        SerialPort stream=null;
        stream = new SerialPort(_sPorts[0], 9600);
        OpenConnectionWithArduino(stream);

        while (stream.IsOpen && stream!=null)
        {
            try
            {
                string line = stream.ReadLine();
                if (!line.Equals("") && line != null) {

                    var result = line.Split(',');
                    float temp = Convert.ToInt32(result[1]) - _ALTITUDE;

                    altimeterReads++; //counting altitude reads for calibrating first altitude variable with potentiometer value.
                    if (altimeterReads > 10 && !IsScreenMoving) altimeterReads = 1; //Preventing program before going out of range.

                    _DELTA_ALT = new Vector3(0.0f, temp, 0.0f);

                    _DISTANCE = Convert.ToInt32(result[0]);
                    _ALTITUDE = Convert.ToInt32(result[1]);

                    Debug.LogWarning("_DELTA_ALT: "+ _DELTA_ALT);
                    stream.BaseStream.Flush();
                    result = null;
                }
            }
            catch(IOException e)
            {
               Debug.LogError(MessageContainer._FAIL_MESSAGE + "\nThis Error message comes from while loop \nMessage: "+ e.Message);
                stream.Close();
                _RESET_SENSORS_VARIABLE();
                _DELTA_ALT = Vector3.zero;
            }
        }

        if (_killThread)
        {
            stream.Close();
            stream = null;
            arduinoThread.Abort();
            Application.Quit();
        }
    }

    private void OpenConnectionWithArduino(SerialPort stream)
    {
        try
        {
            stream.Open();
            if (stream.IsOpen)
            {
               Debug.LogWarning(MessageContainer._SUCCESS_MESSAGE);
            }
        }
        catch (Exception e)
        {
          Debug.LogError(MessageContainer._FAIL_MESSAGE + " Error msg: " + e.Message);
         
            if(_sPorts.Count == 1)
            {
                OpenConnectionWithArduino(stream);
            }

            stream.Close();
        }
    }
#endregion
}
