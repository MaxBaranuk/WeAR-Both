﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class TakeScreenShot : MonoBehaviour 
{
	public Image buttonShare;
    public GameObject modePanel;
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject infoButton;
    public GameObject plusBut;
    public GameObject minusBut;

    public string message;

	private bool _isProcessing = false;

    public void OnEnable()
    {
//        ScreenshotHandler.ScreenshotFinishedSaving += ScreenshotSaved;
    }

    void OnDisable()
    {
//        ScreenshotHandler.ScreenshotFinishedSaving -= ScreenshotSaved;
    }

    void ScreenshotSaved()
    {
#if UNITY_IPHONE || UNITY_IPAD
//		GeneralSharingiOSBridge.ShareTextWithImage (ScreenshotHandler.savedImagePath, "Hello !!! \nThis is post from TheAppGuruz");
#endif
    }

    public void ButtonShare()
	{
		buttonShare.enabled = false;
        modePanel.SetActive(false);
        nextButton.SetActive(false);
        prevButton.SetActive(false);
        infoButton.SetActive(false);
        plusBut.SetActive(false);
        minusBut.SetActive(false);

        if (!_isProcessing) StartCoroutine(ShareScreenshot());

//#if UNITY_ANDROID

//#elif UNITY_IPHONE || UNITY_IPAD
//        byte[] bytes = MyImage.EncodeToPNG ();
//		string path = Application.persistentDataPath + "/MyImage.png";
//		File.WriteAllBytes (path, bytes);
//		string path_ = "MyImage.png";
		
//		StartCoroutine (ScreenshotHandler.Save (path_, "Media Share", true));
//#endif
    }

    public IEnumerator ShareScreenshot()
	{
		_isProcessing = true;
		yield return new WaitForEndOfFrame ();

		Texture2D screenTexture = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, true);
		screenTexture.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
		screenTexture.Apply ();

		byte[] dataToSave = screenTexture.EncodeToPNG ();
        string date = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        Debug.Log(date);
       string path = Application.persistentDataPath + "/wear"+ date + ".png";
//        string path = Application.persistentDataPath + "/wear.png";
        File.WriteAllBytes (path, dataToSave);

        #if UNITY_ANDROID

        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");

            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");

            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));

            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");

            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + path);

            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

            intentObject.Call<AndroidJavaObject>("setType", "image/*");

            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

            currentActivity.Call("startActivity", intentObject);

        #elif UNITY_IPHONE || UNITY_IPAD
//        StartCoroutine (ScreenshotHandler.Save (path, "Media Share", true));
        #endif

        _isProcessing = false;
		buttonShare.enabled = true;
        modePanel.SetActive(true);
        nextButton.SetActive(true);
        prevButton.SetActive(true);
        infoButton.SetActive(true);
        plusBut.SetActive(true);
        minusBut.SetActive(true);
    }


}