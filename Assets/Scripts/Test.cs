using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartPackage("com.google.android.apps.maps");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void StartPackage(string package)
    {
        AndroidJavaObject currentActivity;
        AndroidJavaClass unityClass;
        AndroidJavaObject unityObject, packageManager;
        AndroidJavaObject launch;
        unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        packageManager = currentActivity.Call<AndroidJavaObject>("getPackageManager");
        launch = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", package);
        currentActivity.Call("startActivity", launch);
        
    }

}
