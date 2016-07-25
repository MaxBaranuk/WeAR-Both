using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MainSceneManager : MonoBehaviour {

    public GameObject[] doors;
    public GameObject[] divans;
    public GameObject[] chairs;
    public GameObject[] tables;
    public GameObject[] others;

    public Material[] doorMaterials;
//    public Material[] sofaMaterials;
    public Material[] tableMaterials;

    [SerializeField]
    Material[] chair1Materials;
    [SerializeField]
    Material[] chair2Materials;
    [SerializeField]
    Material[] chair3Materials;
    [SerializeField]
    Material[] sofa1Materials;
    [SerializeField]
    Material[] sofa2Materials;
    [SerializeField]
    Material[] sofa3Materials;
    Material[] currMaterials;

    public Material[] firePlaceMaterials;

    public GameObject[] currentMode;
    public int currentItem = -1;
    int currMatIndex = 0;
    int currSofaMatIndex = 0;
    int currTableMatIndex = 0;
    int currMarmourMatIndex = 0;

    public GameObject nextBut;
    public GameObject prevBut;

    public GameObject infoPanelLand;
    public GameObject infoPanelPort;
    public RectTransform screenshotBut;

    GameObject currInfoPanel;
    bool infoOpen;
    bool isScalePlus;
    bool isScaleMinus;
    float scaleMode;
    // Use this for initialization
    void Start () {
        
        currentMode = chairs;
        currInfoPanel = infoPanelPort;
        currentItem = 1;
        currentMode[currentItem].SetActive(true);
        CheckEnableButtons();
    }

    void OnEnable() {
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
	// Update is called once per frame
	void Update () {
 //       if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        UserInput();
        //if (currInfoPanel != infoPanelPort && Input.deviceOrientation == DeviceOrientation.Portrait)
        //{
        //    currInfoPanel.SetActive(false);
        //    currInfoPanel = infoPanelPort;
        //    if (infoOpen) currInfoPanel.SetActive(true);
        //}
        //if (currInfoPanel != infoPanelLand && (Input.deviceOrientation == DeviceOrientation.LandscapeLeft | Input.deviceOrientation == DeviceOrientation.LandscapeLeft))
        //{
        //    currInfoPanel.SetActive(false);
        //    currInfoPanel = infoPanelLand;
        //    if (infoOpen) currInfoPanel.SetActive(true);
        //}

        if (currInfoPanel != infoPanelPort && Screen.orientation == ScreenOrientation.Portrait)
        {
            currInfoPanel.SetActive(false);
            currInfoPanel = infoPanelPort;
            //screenshotBut.anchorMin = new Vector2(0, 0);
            //screenshotBut.anchorMax = new Vector2(0, 0);
            //screenshotBut.localPosition = new Vector3(120, 120, 0);
            if (infoOpen) currInfoPanel.SetActive(true);
        }
        if (currInfoPanel != infoPanelLand && Screen.orientation == ScreenOrientation.Landscape)
        {
            currInfoPanel.SetActive(false);
            currInfoPanel = infoPanelLand;
            //screenshotBut.anchorMin = new Vector2(1, 1);
            //screenshotBut.anchorMax = new Vector2(1, 1);
            //screenshotBut.localPosition = new Vector3(-120, -120, 0);
            if (infoOpen) currInfoPanel.SetActive(true);
        }


        //if (isScalePlus) {
        //    currentMode[currentItem].transform.localScale = new Vector3(transform.localScale.x+scaleMode, transform.localScale.y + scaleMode, transform.localScale.z + scaleMode);
        //    scaleMode += 0.0005f;
        //}

        //if (isScaleMinus)
        //{
        //    currentMode[currentItem].transform.localScale = new Vector3(transform.localScale.x - scaleMode, transform.localScale.y - scaleMode, transform.localScale.z - scaleMode);
        //    scaleMode += 0.0005f;
        //}

    }

    public void Prev()
    {
        
        if (currentItem > 0&&currentItem!=-1) {
            currentMode[currentItem].SetActive(false);
            currentItem--;
            currentMode[currentItem].SetActive(true);
            CheckEnableButtons();
        } 
        
    }

    public void Next()
    {
        if (currentItem < (currentMode.Length - 1)&&currentItem!=-1) {
            Debug.Log("currentItem"+ currentItem);
            currentMode[currentItem].SetActive(false);
            currentItem++;
            currentMode[currentItem].SetActive(true);
            CheckEnableButtons();
        }
    }

    public void CheckEnableButtons() {
        if (currentItem == 0) prevBut.GetComponent<Button>().interactable = false;
        else prevBut.GetComponent<Button>().interactable = true;
        if (currentItem == currentMode.Length - 1) nextBut.GetComponent<Button>().interactable = false;
        else nextBut.GetComponent<Button>().interactable = true;
    }

    public void ChangeDoorMaterial(GameObject g) {
        g.GetComponent<MeshRenderer>().material = doorMaterials[currMatIndex];
        currMatIndex++;
        if (currMatIndex == doorMaterials.Length) currMatIndex -= doorMaterials.Length;
    }

    public void ChangeTableMaterial(GameObject g)
    {
        g.GetComponent<MeshRenderer>().material = tableMaterials[currTableMatIndex];
        currTableMatIndex++;
        if (currTableMatIndex == tableMaterials.Length) currTableMatIndex -= tableMaterials.Length;
    }
    public void ChangeSofaMaterial(GameObject g)
    {
        switch (g.transform.parent.name) {
            case "sofa_1":
                currMaterials = sofa1Materials;
                break;
            case "sofa_2":
                currMaterials = sofa2Materials;
                break;
            case "sofa_3":
                currMaterials = sofa3Materials;
                break;
            case "armchair_1":
                currMaterials = chair1Materials;
                break;
            case "armchair_2":
                currMaterials = chair2Materials;
                break;
            case "armchair_3":
                currMaterials = chair3Materials;
                break;
        }
        g.GetComponent<MeshRenderer>().material = currMaterials[currSofaMatIndex];
        currSofaMatIndex++;
        if (currSofaMatIndex == currMaterials.Length) currSofaMatIndex -= currMaterials.Length;
    }

    public void ChangeFirePlaceMaterial(GameObject g)
    {
        g.GetComponent<MeshRenderer>().material = firePlaceMaterials[currMarmourMatIndex];
        currMarmourMatIndex++;
        if (currMarmourMatIndex == firePlaceMaterials.Length) currMarmourMatIndex -= firePlaceMaterials.Length;
    }

    void UserInput()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){
                    if (hit.transform.gameObject.tag == "Door") ChangeDoorMaterial(hit.transform.gameObject);
                    if (hit.transform.gameObject.tag == "Table") ChangeTableMaterial(hit.transform.gameObject);                   
                    if (hit.transform.gameObject.tag == "Sofa") ChangeSofaMaterial(hit.transform.gameObject);
                    if (hit.transform.gameObject.tag == "FirePlace") ChangeFirePlaceMaterial(hit.transform.gameObject);
                }

            }
        }
        else {
            if (Input.touchCount==1&&Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){
                    if (hit.transform.gameObject.tag == "Door") ChangeDoorMaterial(hit.transform.gameObject);                 
                    if (hit.transform.gameObject.tag == "Table") ChangeTableMaterial(hit.transform.gameObject);              
                    if (hit.transform.gameObject.tag == "Sofa") ChangeSofaMaterial(hit.transform.gameObject);
                    if (hit.transform.gameObject.tag == "FirePlace") ChangeFirePlaceMaterial(hit.transform.gameObject);
                }
            }
        }
    }

    public void CloseInfoPanel(){
        infoOpen = false;
        currInfoPanel.SetActive(false);
    }

    public void OpenInfoPanel() {
        infoOpen = true;
        currInfoPanel.SetActive(true);
    }

    public void ScalePlusDown() {
        scaleMode = 0.002f;
        isScalePlus = true;
        StartCoroutine(ScalePlus());      
    }

    public void ScalePlusUp() {
        isScalePlus = false;
    }

    public void ScaleMinusDown() {
        scaleMode = 0.002f;
        isScaleMinus = true;
        StartCoroutine(ScaleMinus());
    }
   
    public void ScaleMinusUp() {
        isScaleMinus = false;
    }

    IEnumerator ScalePlus() {
        while (isScalePlus) {
            currentMode[currentItem].transform.localScale = new Vector3(currentMode[currentItem].transform.localScale.x + scaleMode,
                                                                        currentMode[currentItem].transform.localScale.y + scaleMode,
                                                                        currentMode[currentItem].transform.localScale.z + scaleMode);           
            scaleMode += 0.0005f;
            yield return new WaitForSeconds(0.02f);
        }
        
    }

    IEnumerator ScaleMinus() {

        while (isScaleMinus){
            currentMode[currentItem].transform.localScale = new Vector3(currentMode[currentItem].transform.localScale.x - scaleMode,
                                                                       currentMode[currentItem].transform.localScale.y - scaleMode,
                                                                       currentMode[currentItem].transform.localScale.z - scaleMode);
            if (currentMode[currentItem].transform.localScale.x < 0|
               currentMode[currentItem].transform.localScale.y < 0|
               currentMode[currentItem].transform.localScale.z < 0) currentMode[currentItem].transform.localScale = Vector3.zero;
            scaleMode += 0.0005f;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
