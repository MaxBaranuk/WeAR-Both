using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneStateManager : MonoBehaviour 
{
	public static SceneStateManager instance;
    public bool targetFind;
	public List<GameObject> managers;
	public GameObject curentManager;  
    public bool isSelfieMode;

    void Awake () 
	{
		if (instance == null) 
		{
			instance = this;
		}
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

	public void ChangeState(int stateID)
	{
        StartCoroutine(ChangeAfterMenuClose(stateID));
		
	}

    IEnumerator ChangeAfterMenuClose(int stateID) {

        yield return new WaitForSeconds(0.1f);
        if (targetFind)
        {
            curentManager.SetActive(false);
            curentManager = managers[stateID];
            curentManager.SetActive(true);
        }
    }

    void OnDisable()
    {
        curentManager.SetActive(false);
    }
}
