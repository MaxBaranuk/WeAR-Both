using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;

public class LanguageManager : MonoBehaviour {

    string path = "";
    TextAsset GameAsset;
    public Text targetText;
    public Text tableText;
    public Text doorsText;
    public Text divansText;
    public Text chairText;
    public Text otherText;
    public Text infoText;
    public Text doorsInfoPort1Text;
    public Text doorsInfoPort2Text;
    public Text doorsInfoPort3Text;
    public Text doorsInfoLand1Text;
    public Text doorsInfoLand2Text;
    public Text doorsInfoLand3Text;

    public Text brickText;
    public Text tileText;
    public Text doorColorText;
    public Text doorTextureText;
    public Text handsColorText;
    public Text windowFrameText;
    public Text concreteTextureText;
    public Text exitText;

    public Text minionfingersText;
    public Text minionSpeakText;
    public Text minionHeadsText;
    public Text minionFeaturessText;

    public Text floorInfo1Text;
    public Text floorInfo2Text;
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
        XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
        GameAsset = Resources.Load(path) as TextAsset;
        xmlDoc.LoadXml(GameAsset.text); // load the file.
        XmlNodeList levelsList = xmlDoc.GetElementsByTagName("Language");
        XmlNodeList levelcontent = levelsList[0].ChildNodes;

        foreach (XmlNode levelInfo in levelcontent)
        {
            if (levelInfo.Name == "target") targetText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "chairs") chairText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "doors") doorsText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "divans") divansText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "tables") tableText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "other") otherText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "info") infoText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "changeColor") {
                doorsInfoPort1Text.text = "" + levelInfo.InnerText;
                doorsInfoLand1Text.text = "" + levelInfo.InnerText;
            }
            if (levelInfo.Name == "rotate") {
                doorsInfoPort2Text.text = "" + levelInfo.InnerText;
                doorsInfoLand2Text.text = "" + levelInfo.InnerText;
            }
            if (levelInfo.Name == "move") {
                doorsInfoPort3Text.text = "" + levelInfo.InnerText;
                doorsInfoLand3Text.text = "" + levelInfo.InnerText;
            }

            if (levelInfo.Name == "bricks") brickText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "tile") tileText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "doorColor") doorColorText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "doorTexture") doorTextureText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "handsColor") handsColorText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "windowFrame") windowFrameText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "concreteTexture") concreteTextureText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "exit") exitText.text = "" + levelInfo.InnerText;


            if (levelInfo.Name == "fingers") minionfingersText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "minionSpeak") minionSpeakText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "minionHeads") minionHeadsText.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "minionPropeties") minionFeaturessText.text = "" + levelInfo.InnerText;

            if (levelInfo.Name == "floorTap") floorInfo1Text.text = "" + levelInfo.InnerText;
            if (levelInfo.Name == "floorChanger") floorInfo2Text.text = "" + levelInfo.InnerText;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
