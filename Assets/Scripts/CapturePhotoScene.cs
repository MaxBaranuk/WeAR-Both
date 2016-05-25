using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CapturePhotoScene : MonoBehaviour {

    
    public GameObject cam;
    public GameObject glassImage;
    public GameObject galaryPanel;

	private bool takeHiResShot = false;
    
	public void TakeHiResShot()
    {
        takeHiResShot = true;
    }
    
	void LateUpdate()
    {
        if (takeHiResShot)
        {
            RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
            cam.GetComponent<Camera>().targetTexture = rt;
            Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            cam.GetComponent<Camera>().Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            screenShot.Apply();
            cam.GetComponent<Camera>().targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);
            takeHiResShot = false;
            Sprite sp = new Sprite();
            sp = Sprite.Create(screenShot, new Rect(0,0, screenShot.width, screenShot.height), new Vector2(screenShot.width/2, screenShot.height/2), 100);
            galaryPanel.GetComponent<Image>().sprite = sp;
            galaryPanel.SetActive(true);
        }
    }

    public void BackBut() {
        galaryPanel.SetActive(false);
    }

    public void setGlass(Sprite glassIm)
    {
        glassImage.SetActive(true);
        glassImage.GetComponent<Image>().sprite = glassIm;
    }


}
