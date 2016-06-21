using UnityEngine;
using System.Collections;
using System.Xml;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialSceneScript : MonoBehaviour {

    string path = "";
    TextAsset GameAsset;
    public Text download;
    public Text target;
    public Text enjoy;
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
            if (levelInfo.Name == "tutorial_print") download.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "tutorial_target") target.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "tutorial_enjoy") enjoy.text = "" + levelInfo.InnerText;
        }
    }

    public void BackButtonPressed() {
        SceneManager.LoadScene(0);
    }
}
