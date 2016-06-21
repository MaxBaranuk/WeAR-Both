using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Xml;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    string path = "";
    TextAsset GameAsset;
    public Text startBut;
    public Text manualBut;
    public Text downloadBut;
    public Text feedbackBut;
    // Use this for initialization
    void Start () {
        switch (Application.systemLanguage)
        {
            case SystemLanguage.English:
                path = "XML/stringsEn";
                break;
            case SystemLanguage.Russian:
                path = "XML/stringsRu";
                break;
            case SystemLanguage.Ukrainian:
                path = "XML/stringsUa";
                break;
            default:
                path = "XML/stringsEn";
                break;
        }
        SetLanguage(path);
    }


    private void SetLanguage(string path)
    {
        Debug.Log(path);
        XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
        GameAsset = Resources.Load(path) as TextAsset;
        xmlDoc.LoadXml(GameAsset.text); // load the file.
        XmlNodeList levelsList = xmlDoc.GetElementsByTagName("Language");
        XmlNodeList levelcontent = levelsList[0].ChildNodes;

        foreach (XmlNode levelInfo in levelcontent)
        {
            if (levelInfo.Name == "start") startBut.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "manual") manualBut.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "download") downloadBut.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "feedback") feedbackBut.text = "" + levelInfo.InnerText;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
	}

    public void StartAR() {
        SceneManager.LoadScene(1);
    }

    public void ManualButtonPressed() {
        SceneManager.LoadScene(3);
    }

    public void DownloadButtonPressed() {
        Application.OpenURL("https://drive.google.com/folderview?id=0B4JLV0NgSFsERHFyR0lWcUlhTzA&usp=drive_web");
    }

    public void FeedbackButtonPressed() {
        sendMail();
    }

    public void sendMail()
    {

        //email Id to send the mail to
        string email = "info.wearstudio@wear-studio.com";
        //subject of the mail
        string subject = MyEscapeURL("Support");
        //body of the mail which consists of Device Model and its Operating System
        string body = MyEscapeURL("Please Enter your message here\n\n\n\n" +
         "________" +
         "\n\nSend from\n\n" +
         "Model: " + SystemInfo.deviceModel + "\n\n" +
            "OS: " + SystemInfo.operatingSystem + "\n\n");

        //Open the Default Mail App
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);

    }

    string MyEscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }
}
