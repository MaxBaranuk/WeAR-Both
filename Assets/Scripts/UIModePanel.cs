using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIModePanel : MonoBehaviour {

    public GameObject[] modeButtons;
    MainSceneManager manager;
    GameObject currButton;
    DoorsUIManager uiManager;

	// Use this for initialization
	void Start () {
        currButton = modeButtons[0];
        manager = GameObject.Find("SceneManager").GetComponent<MainSceneManager>();
        uiManager = GetComponentInParent<DoorsUIManager>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void TablesSelect()
    {
        if (manager.currentItem == -1) manager.currentItem = 0;
        manager.nextBut.GetComponent<Button>().interactable = true;
        currButton.GetComponent<Button>().interactable = true;
        modeButtons[0].GetComponent<Button>().interactable = false;
        currButton = modeButtons[0];
        manager.currentMode[manager.currentItem].SetActive(false);
        manager.currentItem = 0;
        manager.currentMode = manager.tables;
        manager.currentMode[0].SetActive(true);
        manager.CheckEnableButtons();
    }

    public void DoorsSelect() {
        manager.nextBut.GetComponent<Button>().interactable = true;
        if (manager.currentItem == -1) manager.currentItem = 0;
        currButton.GetComponent<Button>().interactable = true;
        modeButtons[1].GetComponent<Button>().interactable = false;
        currButton = modeButtons[1];
        manager.currentMode[manager.currentItem].SetActive(false);
        manager.currentItem = 0;
        manager.currentMode = manager.doors;
        manager.currentMode[0].SetActive(true);
        manager.CheckEnableButtons();
    }

    public void divansSelect() {
        manager.nextBut.GetComponent<Button>().interactable = true;
        if (manager.currentItem == -1) manager.currentItem = 0;
        currButton.GetComponent<Button>().interactable = true;
        modeButtons[2].GetComponent<Button>().interactable = false;
        currButton = modeButtons[2];
        manager.currentMode[manager.currentItem].SetActive(false);
        manager.currentItem = 0;
        manager.currentMode = manager.divans;
        manager.currentMode[0].SetActive(true);
        manager.CheckEnableButtons();
    }

    public void ChairSelect() {
        manager.nextBut.GetComponent<Button>().interactable = true;
        if (manager.currentItem == -1) manager.currentItem = 0;
        currButton.GetComponent<Button>().interactable = true;
        modeButtons[3].GetComponent<Button>().interactable = false;
        currButton = modeButtons[3];
        manager.currentMode[manager.currentItem].SetActive(false);
        manager.currentItem = 0;
        manager.currentMode = manager.chairs;
        manager.currentMode[0].SetActive(true);
        manager.CheckEnableButtons();
    }

    public void OtherSelect()
    {
        manager.nextBut.GetComponent<Button>().interactable = true;
        if (manager.currentItem == -1) manager.currentItem = 0;
        currButton.GetComponent<Button>().interactable = true;
        modeButtons[4].GetComponent<Button>().interactable = false;
        currButton = modeButtons[4];
        manager.currentMode[manager.currentItem].SetActive(false);
        manager.currentItem = 0;
        manager.currentMode = manager.others;
        manager.currentMode[0].SetActive(true);
        manager.CheckEnableButtons();
    }
}
