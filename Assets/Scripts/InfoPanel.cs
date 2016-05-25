using UnityEngine;
using System.Collections;

public class InfoPanel : MonoBehaviour 
{
    EducationView manager;

    void Start() {
        manager = GameObject.Find("InfoManager").GetComponent<EducationView>();

    }

   public void OpenPanel() 
	{
        StartCoroutine(Open());
    }

	public void ClosePanel() 
	{
        StartCoroutine(Close(false));      
    }

    public void ShowVideo() {
        StartCoroutine(Close(true));
    }

	IEnumerator Open() {

        float alpha = 0;
        while (alpha < 1f) {
            alpha += 0.1f;
            GetComponent<CanvasGroup>().alpha = alpha;
            yield return new WaitForSeconds(0.01f);

		}
        alpha = 1;
        
    }

	IEnumerator Close(bool video)
	{
        float alpha = 1;
        while (alpha > 0f)
        {
            alpha -= 0.1f;
            GetComponent<CanvasGroup>().alpha = alpha;
            yield return new WaitForSeconds(0.01f);

        }
        alpha = 0;
        gameObject.SetActive(false);
        manager.tv.SetActive(true);

        if (video) manager.tv.GetComponent<TV>().ShowTv();
        else manager.infoPanels.SetActive(true);
    }
}
