using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlassGalaryItem : MonoBehaviour {

    
    public bool isButtonClicked;
    
	public void SetGlass() {
         if (isButtonClicked) {
                Sprite im = gameObject.GetComponent<Image>().sprite;
                GetComponent<FixScrollRect>().sceneController.GetComponent<CapturePhotoScene>().setGlass(im);
        }
        
    }
}
