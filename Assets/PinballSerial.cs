using UnityEngine;
using System.Collections;

using System.IO.Ports;
using System.Threading;
using System;

public class PinballSerial : MonoBehaviour {
    //Serial Variables
    private SerialPort sp = new SerialPort("COM5", 9600);

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
				sp = new SerialPort("COM5", 9600);
			}
            sp.Open();
            sp.ReadTimeout = 10000;

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
				if (values.Length < 1 || values[0] == "") {
					left = false;
				} else {
					left = (int.Parse(values[0]) > 0) ? true : false;
				}
				// Parse right
				if (values.Length < 2 || values[1] == "" || values[1] == "0") {
					right = false;
				} else {
					right = true;
				}
				// Parse coin
				if (values.Length < 3 || values[2] == "" || values[2] == "0") {
					coin = false;
				} else {
					coin = true;
				}
				// Parse potentiometer value
				if (values.Length < 4 || values[3] == "") {
					plunger = 1;
				} else {
					plunger = int.Parse(values[3]);
				}
				// Parse potentiometer value
				if (values.Length < 5 || values[4] == "") {
					tilt = 0.0f;
				} else {
					tilt = float.Parse(values[4]);
				}
				// Debug print all values
				print ("Left: " + left + "; Right: " + right + "; Coin = " + coin
				       + ";Plunger = " + plunger + ";Tilt = " + tilt);
				// Flush the stream
				sp.BaseStream.Flush();
			} catch (Exception ee) {
                Debug.Log(ee.ToString());
            }
        }
    }

	void OnDestroy() {
		sp.Close ();
	}
}
