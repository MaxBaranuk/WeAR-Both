using UnityEngine;
using System.Collections;

public class DoorsMenuButton : MonoBehaviour {

    RectTransform recTransform;
    float step = 40;
	// Use this for initialization
	void Start () {
        recTransform = GetComponent<RectTransform>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Open() {
        StartCoroutine(OpenIE());
    }

    public void Close() {
        StartCoroutine(CloseIE());
    }

    IEnumerator OpenIE() {
        step = 60;
        while (recTransform.localPosition.x > -155) {
            recTransform.localPosition = new Vector3(recTransform.localPosition.x-step, recTransform.localPosition.y, recTransform.localPosition.z);
            yield return new WaitForSeconds(0.01f);
            if (recTransform.localPosition.x <= -90 & recTransform.localPosition.x >= -140) step = 8;
            if (recTransform.localPosition.x <= -140 & recTransform.localPosition.x >= -155) step =4;
        }
        recTransform.localPosition = new Vector3(-155, recTransform.localPosition.y, recTransform.localPosition.z);
    }

    IEnumerator CloseIE() {

        while (recTransform.localPosition.x < 145)
        {
            recTransform.localPosition = new Vector3(recTransform.localPosition.x + 60, recTransform.localPosition.y, recTransform.localPosition.z);
            yield return new WaitForSeconds(0.01f);
        }
        recTransform.localPosition = new Vector3(145, recTransform.localPosition.y, recTransform.localPosition.z);
    }
}
