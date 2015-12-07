using UnityEngine;
using System.Collections;

using System.IO.Ports;
using System.Threading;
using System;

public class PinballSerial : MonoBehaviour {
    //Serial Variables
    private SerialPort sp = new SerialPort("COM3", 9600);

    // Update Variables
    public static bool left = false;
	public static bool right = false;
	public static bool coin = false;
	public static int plunger = 1;
	public static float tilt = 0.0f;

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
            sp.ReadTimeout = 110;

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
	}


    private void runPolling() {
		while (sp.IsOpen) {
            try {
			    string str = sp.ReadLine();
				string[] values = str.Split (',');
				// Parse left
				if (values.Length > 0 || values[0] == "" || values[0].Equals ("0")) {
					left = false;
				} else {
					left = true;
				}
				// Parse right
				if (values.Length > 1 || values[1] == "" || values[1].Equals ("0")) {
					left = false;
				} else {
					left = true;
				}
				// Parse coin
				if (values.Length > 2 || values[2] == "" || values[2].Equals ("0")) {
					left = false;
				} else {
					left = true;
				}
				// Parse potentiometer value
				if (values.Length > 3 || values[3] == "") {
					plunger = 1;
				} else {
					plunger = int.Parse(values[3]);
				}
				// Parse potentiometer value
				if (values.Length > 4 || values[4] == "") {
					tilt = 0.0f;
				} else {
					tilt = float.Parse(values[4]);
				}


				print ("Data Received : " + str);

				// Flush the stream
				sp.BaseStream.Flush();

            } catch (TimeoutException te) {

			} catch (Exception ee) {
                Debug.Log(ee.ToString());
            }
        }
    }

	void OnDestroy() {
		sp.Close ();
	}
}
