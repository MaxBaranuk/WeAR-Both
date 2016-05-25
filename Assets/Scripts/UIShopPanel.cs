using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIShopPanel : MonoBehaviour {

    public GameObject[] modeButtons;
    public MinionStateChanger minion;
    GameObject currButton;

	// Use this for initialization
	void Start () {
        currButton = modeButtons[0];
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void ShowButtons() {
        StartCoroutine(Show());
    }

    public void HideButtons() {
        StartCoroutine(Hide());
    }

    public void HeadSelect() {
        currButton.GetComponent<Button>().interactable = true;
        modeButtons[0].GetComponent<Button>().interactable = false;
        currButton = modeButtons[0];
        minion.currentShopState = MinionStateChanger.ClothesState.Hat;
    }

    public void WearSelect() {
        currButton.GetComponent<Button>().interactable = true;
        modeButtons[1].GetComponent<Button>().interactable = false;
        currButton = modeButtons[1];
        minion.currentShopState = MinionStateChanger.ClothesState.Clothes;
    }

    IEnumerator Show() {
        foreach (GameObject g in modeButtons)
        {
            g.SetActive(true);
            g.GetComponent<UIButton>().OpenButton();
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Hide() {
        foreach (GameObject g in modeButtons)
        {
            g.GetComponent<UIButton>().CloseButton();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }


}
