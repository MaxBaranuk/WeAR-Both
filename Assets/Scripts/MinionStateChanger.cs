using UnityEngine;
using System.Collections;

public class MinionStateChanger : MonoBehaviour {

    public enum ClothesState { Hat, Clothes, Nothing}

    public GameObject[] defaultClothes;
    public GameObject[] gameClothes;
    
    public GameObject[] girlClothes;
    public GameObject[] havaiClothes;    
    public GameObject[] gadyaClothes;
    public GameObject[] deerClothes;

    public GameObject[] girlHat;
    public GameObject[] deerHat;
    public GameObject[] hatClothes;
    public GameObject[] hat2Clothes;
    public GameObject[] sombreroClothes;
    public GameObject[] hatHavai;
    public GameObject[] hatGadya;
    public GameObject banana;
    public ClothesState currentShopState = ClothesState.Nothing;
    GameObject[] curr;
    GameObject[] currHat;
    GameObject[] currCloth;

    int currHatIndex = 0;
    int currClothIndex = 0;
    public Animator anim;
    public AudioSource source;
    public AudioClip bananaSound;
    public AudioClip belloSound;

    bool isGameState;
    public bool isSite; 
    // Use this for initialization
    void Start () {
        curr = defaultClothes;
//        anim = GetComponent<Animator>();
 //       source = GetComponent<AudioSource>();
        currHat = girlHat;
        currCloth = girlClothes;
        InvokeRepeating("PlayRandomAnimation", 1, 15);
    }
	
	// Update is called once per frame
	void Update () {
        UserInput();
    }

    public void SetDefaultClothes()
    {
        anim.ResetTrigger("Banana");
        anim.ResetTrigger("Bello");
        isGameState = false;
        StartCoroutine(DefaultClothe());
    }

    public void SetGameClothes() {
        anim.ResetTrigger("Banana");
        anim.ResetTrigger("Bello");
        isGameState = true;
        StartCoroutine(GameState());
    }

    public void SetShopState() {
        anim.ResetTrigger("Banana");
        anim.ResetTrigger("Bello");
        isGameState = false;
        StartCoroutine(ShopState());
    }

    void PlayRandomAnimation(){
        if (!isGameState&& !SceneStateManager.instance.isSelfieMode) PlayExtraAnim();    
    }

    void PlayExtraAnim(){
        string currTrigger = "";
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle1"))
        {
            currTrigger = "Idle1Start";
            anim.SetTrigger("Idle1Stop");
            anim.SetTrigger("Idle1Exit");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle2"))
        {
            currTrigger = "Idle2";
            anim.SetTrigger("Null");
        }

        if (Random.value > 0.5f) StartCoroutine(Banana(currTrigger));
        else StartCoroutine(Bello(currTrigger));
    }

    IEnumerator Banana(string currTrigger)
    {
        anim.SetTrigger("Banana");
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Banana"));
        banana.SetActive(true);
        yield return new WaitForSeconds(1.133f);
        source.PlayOneShot(bananaSound);
        anim.SetTrigger("BananaExit");
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Null"));
        banana.SetActive(false);
        if(!isGameState) anim.SetTrigger(currTrigger);
    }

    IEnumerator Bello(string currTrigger) {
        anim.SetTrigger("Bello");
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Bello"));
        yield return new WaitForSeconds(1.133f);
        source.PlayOneShot(belloSound);
        anim.SetTrigger("BelloExit");
        if (!isGameState) anim.SetTrigger(currTrigger);
    }

    IEnumerator ShopState() {
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Start Idle1"));
        currentShopState = ClothesState.Nothing;
        foreach (GameObject g in curr)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in currCloth)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in currHat)
        {
            g.SetActive(true);
        }
    }

    IEnumerator GameState() {
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("StartGame"));
        foreach (GameObject g in curr)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in currHat)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in currCloth)
        {
            g.SetActive(false);
        }
        curr = gameClothes;
        foreach (GameObject g in curr)
        {
            g.SetActive(true);
        }
    }

    IEnumerator DefaultClothe() {
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Idle2"));
        foreach (GameObject g in curr)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in currHat)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in currCloth)
        {
            g.SetActive(false);
        }
        curr = defaultClothes;
        foreach (GameObject g in curr)
        {
            g.SetActive(true);
        }
    }

    public void ChangeHats() {

        foreach (GameObject g in currHat)
        {
            g.SetActive(false);
        }
        switch (currHatIndex){

            case 0:
                currHat = girlHat;
                break;
            case 1:
                currHat = deerHat;
                break;
            case 2:
                currHat = hatClothes;
                break;
            case 3:
                currHat = hat2Clothes;
                break;
            case 4:
                currHat = sombreroClothes;
                break;
            case 5:
                currHat = hatHavai;
                break;
            case 6:
                currHat = hatGadya;
                break;

        }
        foreach (GameObject g in currHat)
        {
            g.SetActive(true);
        }
        currHatIndex++;
        if (currHatIndex > 6) currHatIndex = 0;
    }

    public void ChangeClothe() {

        foreach (GameObject g in currCloth)
        {
            g.SetActive(false);
        }
        switch (currClothIndex) {

            case 0:
                currCloth = girlClothes;
                break;
            case 1:
                currCloth = havaiClothes;
                break;
            case 2:
                currCloth = gadyaClothes;
                break;
            case 3:
                currCloth = deerClothes;
                break;
        }
        foreach (GameObject g in currCloth)
        {
            g.SetActive(true);
        }
        currClothIndex++;
        if (currClothIndex > 3) currClothIndex = 0;
    }

    public void UserInput()
    {
        if (!Application.isEditor)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.transform.gameObject.tag == "Minion")
                    {
                        if (currentShopState == ClothesState.Hat) ChangeHats();
                        if (currentShopState == ClothesState.Clothes) ChangeClothe();
                    }
                }

            }
        }

        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.transform.gameObject.tag == "Minion")
                    {
                        if (currentShopState == ClothesState.Hat) ChangeHats();
                        if (currentShopState == ClothesState.Clothes) ChangeClothe();
                    }
                }

            }
        }

    }

}
