using UnityEngine;


public class EducationView : MonoBehaviour  
{
	public static EducationView instance;

    public GameObject [] Ipanels;
    public GameObject tv;
    public GameObject infoPanels;
    Animator anim;
    public GameObject minion;
    public GameObject shadow;
    public GameObject platform;
    MinionStateChanger minionClothe;

    void Awake()
	{
		if (instance == null) {
			instance = this;
		}
        anim = minion.GetComponent<Animator>();
        minionClothe = minion.GetComponent<MinionStateChanger>();
    }

    void OnEnable()
    {
        minion.SetActive(true);
        shadow.SetActive(true);
        if (minionClothe.isSite) platform.SetActive(true);
        minionClothe.SetDefaultClothes();
        anim.SetTrigger("Null");
        anim.SetTrigger("Idle2");
    }
        void Update()
	{
		UserInput ();

	}

    public void UserInput()
	{
        if (!Application.isEditor)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.transform.gameObject.tag == "Information" && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                    {
                        Debug.Log(hit.transform.name);

                        switch (hit.transform.name)
                        {
                            case "Info1":
                                OpenLotInfo(0);
                                break;
                            case "Info2":
                                OpenLotInfo(1);
                                break;
                            case "Info3":
                                OpenLotInfo(2);
                                break;
                            case "Info4":
                                OpenLotInfo(3);
                                break;
                            case "Video":
                                OpenLotInfo(4);
                                break;
                        }
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

                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.transform.gameObject.tag == "Information" && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                    {
                        Debug.Log(hit.transform.name);

                        switch (hit.transform.name)
                        {
                            case "Info1":
                                OpenLotInfo(0);
                                break;
                            case "Info2":
                                OpenLotInfo(1);
                                break;
                            case "Info3":
                                OpenLotInfo(2);
                                break;
                            case "Info4":
                                OpenLotInfo(3);
                                break;
                            case "Video":
                                OpenLotInfo(4);
                                break;
                        }
                    }
                }
            }
        }


	}

	public void OpenLotInfo(int index)
	{
        Ipanels[index].SetActive(true);
        Ipanels[index].GetComponent<InfoPanel>().OpenPanel();
        infoPanels.SetActive(false);

    }

    void OnDisable()
    {
        anim.SetTrigger("Null");
        minion.SetActive(false);
        shadow.SetActive(false);
        platform.SetActive(false);
    }

    }
