using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
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

    private void MakeElementActive(GameObject element)
    {
        element.SetActive(true);
    }

}
