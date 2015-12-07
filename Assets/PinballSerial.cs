using UnityEngine;
using System.Collections;

using System.IO.Ports;
using System;

public class PinballSerial : MonoBehaviour {
    //Serial Variables
    private SerialPort sp = new SerialPort("COM5", 9600);

    // Update Variables
    bool left = false;
    bool right = false;
    float speed = 0.0f;

	// Use this for initialization
	void Start () {
        try
        {
            Debug.Log("Opening ports");
            //serialPort1
            sp.Open();
            sp.ReadTimeout = 30;
            //sp.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort_DataRecieved);

            Debug.Log("Ports openned");
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (sp != null) {
            Debug.Log(sp.ReadLine());
        } else {
            Debug.Log("Serial is null");
        }
	}


    private void serialPort_DataRecieved(object sender, SerialDataReceivedEventArgs e)
    {
        Debug.Log("got something");
        if (sp.IsOpen)
        {
            try
            {
                string spIn = sp.ReadLine();
                Debug.Log("serial port input:" + spIn);

            }
            catch (Exception ee)
            {
                Debug.Log(ee.ToString());
            }
        }
    }
}
