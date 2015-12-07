using UnityEngine;
using System.Collections;

using System.IO.Ports;
using System.Threading;
using System;

public class PinballSerial : MonoBehaviour {
    //Serial Variables
    private SerialPort sp = new SerialPort("COM3", 9600);

    // Update Variables
    bool left = false;
    bool right = false;
	bool coin = false;
    int pot = 0;

	// Use this for initialization
	void Start () {
        try
        {
            Debug.Log("Opening ports");
            //serialPort
			if (sp.IsOpen) {
				sp.Close();
				sp = new SerialPort("COM3", 9600);
			}
            sp.Open();
            sp.ReadTimeout = 50;

            Debug.Log("Ports openned");
			Thread polling = new Thread(runPolling);
			polling.Start();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (sp != null) {
            //Debug.Log(sp.ReadByte());
        } else {
            Debug.Log("Serial is null");
        }
	}


    private void runPolling() {
		while (sp.IsOpen) {
            try
            {
				int str = sp.ReadByte();
				print ("Data Received : " + str);

            }
            catch (Exception ee)
            {
                Debug.Log(ee.ToString());
            }
        }
    }

	void OnDestroy() {
		sp.Close ();
	}
}
