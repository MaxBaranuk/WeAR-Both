using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class UserInterfaceManager : MonoBehaviour
{
    #region SingleTone
    public static UserInterfaceManager _instance;
    
    public static UserInterfaceManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UserInterfaceManager>();
            }
            return _instance;
        }
    }
#endregion

    [SerializeField] private GameObject InfoWindow;
    [SerializeField] private UnityEngine.UI.Image _infoImage;

    public void InfoWindowActivate()
    {
        MakeElementActive(InfoWindow);

        _infoImage.sprite = Resources.Load<Sprite>(Screen.orientation == ScreenOrientation.LandscapeRight || Screen.orientation == ScreenOrientation.LandscapeLeft ? "infoLandscape" : "infoPortrait");
    }

    private void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }
    
    private void MakeElementActive(GameObject element)
    {
        if (element != null) element.SetActive(!element.activeSelf);
    }
}
