using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTest : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro;

	// Use this for initialization
	void Start () {
        gyroEnabled = EnableGyro();
        if (gyroEnabled)
        {
            //gyro.updateInterval = 0.1f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y,((GyroToUnity(gyro.attitude)).eulerAngles.z) + 90);
	}

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }


    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            print("Supports");
            return true;
        }

        print("Doesnt support");
        return false;
    }
}
