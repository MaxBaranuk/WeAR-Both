using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Vuforia;

public class UInewManager : MonoBehaviour {

    public MinionStateChanger minion;

    public GameObject [] buttons;
    public GameObject buttonsPanel;
    public GameObject menuButton;
    public GameObject soundButton;
    public GameObject selfiePanel;
    public GameObject galaryPanel;

    public Sprite soundOn;
    public Sprite soundOff;
    public Sprite menu;
    public Sprite menuExit;
    public AudioSource source;

	void Start () {
//        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
//        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    public void OpenInfoScene() {
        if (SceneStateManager.instance.curentManager != SceneStateManager.instance.managers[1])
        {
            SceneStateManager.instance.ChangeState(1);
//            minion.SetDefaultClothes();
        }
        CloseButtons();
    }

    public void OpenGameScene() {
        if (SceneStateManager.instance.curentManager != SceneStateManager.instance.managers[2]) {
            SceneStateManager.instance.ChangeState(2);
//            minion.SetGameClothes();
        }       
        CloseButtons();
    }

    public void OpenShopScene() {
        if (SceneStateManager.instance.curentManager != SceneStateManager.instance.managers[3])
        {
            SceneStateManager.instance.ChangeState(3);
//            minion.SetShopState();
        }
        CloseButtons();
    }

    public void OpenSelfieScene() {
        if (SceneStateManager.instance.curentManager != SceneStateManager.instance.managers[4])
        {
            SceneStateManager.instance.ChangeState(4);
        }
        CloseButtons();
    }

    public void OpenGalaryscene() {
        selfiePanel.SetActive(false);
        galaryPanel.SetActive(true);
    }



    public void SwitchSound() {
        if (source.mute)
        {
            source.mute = false;
            soundButton.GetComponent<UnityEngine.UI.Image>().sprite = soundOn;            
        }
        else {
            source.mute = true;
            soundButton.GetComponent<UnityEngine.UI.Image>().sprite = soundOff;
        }
        CloseButtons();
    }

    public void SwitchMenu() {
        if (buttonsPanel.activeSelf)
        {
            menuButton.GetComponent<UnityEngine.UI.Image>().sprite = menu;
            StartCoroutine(Close());
            
        }
        else {
            menuButton.GetComponent<UnityEngine.UI.Image>().sprite = menuExit;
            StartCoroutine(Open());            
        }
    }

    public void OpenButtons(){
        menuButton.GetComponent<UnityEngine.UI.Image>().sprite = menuExit;
        StartCoroutine(Open());
       
    }

    public void CloseButtons()
    {
        menuButton.GetComponent<UnityEngine.UI.Image>().sprite = menu;
        StartCoroutine(Close());        
    }
    
    IEnumerator Open() {
        if (SceneStateManager.instance.isSelfieMode) {
            //CameraDevice.Instance.Stop();
            //CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_DEFAULT);
            //CameraDevice.Instance.Start();
            selfiePanel.SetActive(false);
        } 
        buttonsPanel.SetActive(true);
        menuButton.GetComponent<Button>().interactable = false;

        for (int i = 1; i < buttons.Length; i++) { 

                buttons[i].SetActive(true);
                buttons[i].GetComponent<UIButton>().OpenButton();
            yield return new WaitForSeconds(0.08f);
        }
        yield return new WaitForSeconds(0.3f);
        menuButton.GetComponent<Button>().interactable = true;
        buttons[0].GetComponent<Button>().interactable = true;
        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }

    IEnumerator Close() {
        menuButton.GetComponent<Button>().interactable = false;
        buttons[0].GetComponent<Button>().interactable = false;

        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }

        for (int i = 1; i < buttons.Length; i++) {
            buttons[i].GetComponent<UIButton>().CloseButton();
            yield return new WaitForSeconds(0.08f);
        }
        yield return new WaitForSeconds(0.3f);
        buttonsPanel.SetActive(false);
        menuButton.GetComponent<Button>().interactable = true;
        if (SceneStateManager.instance.isSelfieMode)
        {
            //CameraDevice.Instance.Stop();
            //CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);
            //CameraDevice.Instance.Start();
            selfiePanel.SetActive(true);
        }
    }

    void OnDisable()
    {
        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<RectTransform>().localPosition = Vector3.zero;
            buttons[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            buttons[i].SetActive(false);
            buttonsPanel.SetActive(false);
            menuButton.GetComponent<Button>().interactable = true;
            menuButton.GetComponent<UnityEngine.UI.Image>().sprite = menu;
        }
    }


}
