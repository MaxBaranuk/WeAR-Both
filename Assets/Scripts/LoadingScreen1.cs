using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen1 : MonoBehaviour {

	public Text loadText;
	public int counter = 0;     
	public AsyncOperation loadOp;



	void Start()    
	{   
		loadText.GetComponent<Text> ();
        loadOp = SceneManager.LoadSceneAsync(1);
	}
	void LateUpdate()    
	{    
		loadText.text =  "Loading " + (int) (loadOp.progress * 100) + "%";    
		counter++;    
	}    
}
