using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoorsUIManager : MonoBehaviour {

    public GameObject menuButton;
    public GameObject screenshotBut;
    public GameObject plusBut;
    public GameObject minusBut;
    public GameObject nextBut;
    public GameObject prevBut;
    public GameObject[] menuButtons;
    public MainSceneManager manager;
    // Use this for initialization
    void Start () {
//        manager = GameObject.Find("SceneManager").GetComponent<MainSceneManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenMenu() {
        StartCoroutine(Open());
    }

    public void CloseMenu() {
        StartCoroutine(Close());
    }

    IEnumerator Open() {
        manager.currentMode[manager.currentItem].SetActive(false);

        menuButton.GetComponent<Image>().enabled = false;
        plusBut.SetActive(false);
        minusBut.SetActive(false);
        nextBut.SetActive(false);
        prevBut.SetActive(false);
        screenshotBut.SetActive(false);

        foreach (GameObject g in menuButtons) {
            g.GetComponent<DoorsMenuButton>().Open();
            yield return new WaitForSeconds(0.1f);
        }
       
    }

    IEnumerator Close() {

        //foreach (GameObject g in menuButtons)
        //{
        //    g.GetComponent<DoorsMenuButton>().Close();
        //    yield return new WaitForSeconds(0.2f);
        //}

        for (int i = menuButtons.Length - 1; i >= 0; i--) {
            menuButtons[i].GetComponent<DoorsMenuButton>().Close();
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitUntil(() => menuButtons[0].GetComponent<RectTransform>().position.x!=145);
        plusBut.SetActive(true);
        minusBut.SetActive(true);
        nextBut.SetActive(true);
        prevBut.SetActive(true);
        screenshotBut.SetActive(true);
        menuButton.GetComponent<Image>().enabled = true;

        manager.nextBut.GetComponent<Button>().interactable = true;
        manager.currentMode[manager.currentItem].SetActive(true);
//        manager.currentItem = 0;
        manager.CheckEnableButtons();
//        manager.currentMode[0].SetActive(true);
    }

    public void TablesSelect()
    {
        
        manager.currentItem = 0;
        manager.currentMode = manager.tables;
        CloseMenu();
    }

    public void DoorsSelect()
    {
        
        manager.currentItem = 0;
        manager.currentMode = manager.doors;
        CloseMenu();
    }

    public void divansSelect()
    {
        
        manager.currentItem = 0;
        manager.currentMode = manager.divans;
        CloseMenu();
    }

    public void ChairSelect()
    {
        
        manager.currentItem = 0;
        manager.currentMode = manager.chairs;
        CloseMenu();
    }

    public void OtherSelect()
    {
        
        manager.currentItem = 0;
        manager.currentMode = manager.others;
        CloseMenu();
    }

    public void Infoselect() {
        manager.OpenInfoPanel();
        CloseMenu();
    }

    public void Exit() {
        CloseMenu();
    }

    void OnDisable()
    {
        for (int i = 0; i < menuButtons.Length; i++)
        {
            menuButtons[i].GetComponent<RectTransform>().localPosition = new Vector3(145, menuButtons[i].GetComponent<RectTransform>().localPosition.y, 0);
            plusBut.SetActive(true);
            minusBut.SetActive(true);
            nextBut.SetActive(true);
            prevBut.SetActive(true);
            screenshotBut.SetActive(true);
            menuButton.GetComponent<Image>().enabled = true;

            manager.nextBut.GetComponent<Button>().interactable = true;
            manager.currentMode[manager.currentItem].SetActive(true);
        }
    }
}
