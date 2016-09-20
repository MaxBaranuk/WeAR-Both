using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {

    public Sprite[] loadingImages;
	public GameObject image;
	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
		StartCoroutine(LoadALevel(2));
        StartCoroutine(ShowImages()); 
	}
	
	IEnumerator ShowImages() {
        int count = 0;
        while (true) {
            image.GetComponent<Image>().sprite = loadingImages[count];
            count++;
            if (count == 9) count = 0;
            yield return new WaitForSeconds(0.3f);
        }

    }
	private IEnumerator LoadALevel(int levelName)
	{
		SceneManager.LoadSceneAsync(levelName);
		yield return null;
	}
}
