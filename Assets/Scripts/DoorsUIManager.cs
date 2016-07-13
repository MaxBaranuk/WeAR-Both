using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoorsUIManager : MonoBehaviour {

    //public GameObject menuButton;
    public RectTransform screenshotBut;
    //public GameObject plusBut;
    //public GameObject minusBut;
    //public GameObject nextBut;
    //public GameObject prevBut;

//    public GameObject[] menuButtons;
    public MainSceneManager manager;
//    ScreenOrientation currOrientation;
    Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
//        currOrientation = ScreenOrientation.Portrait;
//        manager = GameObject.Find("SceneManager").GetComponent<MainSceneManager>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (currOrientation != Screen.orientation && Screen.orientation == ScreenOrientation.Portrait) {
        //    screenshotBut.anchorMin = new Vector2(0, 0);
        //    screenshotBut.anchorMax = new Vector2(0, 0);
        //    screenshotBut.localPosition = new Vector3(120,120,0);          
        //    currOrientation = ScreenOrientation.Portrait;
        //}
        //if (currOrientation != Screen.orientation && Screen.orientation == ScreenOrientation.Landscape)
        //{
        //    screenshotBut.anchorMin = new Vector2(1, 1);
        //    screenshotBut.anchorMax = new Vector2(1, 1);
        //    screenshotBut.localPosition = new Vector3(-120, -120, 0);           
        //    currOrientation = ScreenOrientation.Landscape;
        //}
    }

    public void OpenMenu() {
        anim.SetTrigger("Open");
        manager.currentMode[manager.currentItem].SetActive(false);
        //        StartCoroutine(Open());
    }

    public void CloseMenu() {
        anim.SetTrigger("Close");
        manager.currentMode[manager.currentItem].SetActive(true);
 //       manager.currentItem = 0;
//        manager.currentMode[0].SetActive(true);
        //        StartCoroutine(Close());
    }

//    IEnumerator Open() {
//        manager.currentMode[manager.currentItem].SetActive(false);

//        menuButton.GetComponent<Image>().enabled = false;
//        plusBut.SetActive(false);
//        minusBut.SetActive(false);
//        nextBut.SetActive(false);
//        prevBut.SetActive(false);
//        screenshotBut.SetActive(false);

//        foreach (GameObject g in menuButtons) {
//            g.GetComponent<DoorsMenuButton>().Open();
//            yield return new WaitForSeconds(0.1f);
//        }
       
//    }

//    IEnumerator Close() {

//        //foreach (GameObject g in menuButtons)
//        //{
//        //    g.GetComponent<DoorsMenuButton>().Close();
//        //    yield return new WaitForSeconds(0.2f);
//        //}

//        for (int i = menuButtons.Length - 1; i >= 0; i--) {
//            menuButtons[i].GetComponent<DoorsMenuButton>().Close();
//            yield return new WaitForSeconds(0.1f);
//        }

//        yield return new WaitUntil(() => menuButtons[0].GetComponent<RectTransform>().position.x!=145);
//        plusBut.SetActive(true);
//        minusBut.SetActive(true);
//        nextBut.SetActive(true);
//        prevBut.SetActive(true);
//        screenshotBut.SetActive(true);
//        menuButton.GetComponent<Image>().enabled = true;

//        manager.nextBut.GetComponent<Button>().interactable = true;
//        manager.currentMode[manager.currentItem].SetActive(true);
////        manager.currentItem = 0;
//        manager.CheckEnableButtons();
////        manager.currentMode[0].SetActive(true);
//    }

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

    //void OnDisable()
    //{
    //    CloseMenu();

    //    //for (int i = 0; i < menuButtons.Length; i++)
    //    //{
    //    //    menuButtons[i].GetComponent<RectTransform>().localPosition = new Vector3(150, menuButtons[i].GetComponent<RectTransform>().localPosition.y, 0);
    //    //    plusBut.SetActive(true);
    //    //    minusBut.SetActive(true);
    //    //    nextBut.SetActive(true);
    //    //    prevBut.SetActive(true);
    //    //    screenshotBut.SetActive(true);
    //    //    menuButton.GetComponent<Image>().enabled = true;

    //    //    manager.nextBut.GetComponent<Button>().interactable = true;
    //    //    manager.currentMode[manager.currentItem].SetActive(true);
    //    //}
    //}
}
