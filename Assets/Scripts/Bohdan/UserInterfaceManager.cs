using UnityEngine;
using System.Collections;
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

    public void InfoWindowActivate()
    {
        MakeElementActive(InfoWindow);
    }

    private void MakeElementActive(GameObject element)
    {
        if (!element.activeSelf)
            element.SetActive(true);
        else
            element.SetActive(false);
    }
}
