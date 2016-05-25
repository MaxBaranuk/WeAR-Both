using UnityEngine;
using UnityEngine.UI;

public class ShopScene : MonoBehaviour 
{
    public static ShopScene instance;
    Animator anim;
    public GameObject minion;
    public GameObject shadow;
    public GameObject platform;
    MinionStateChanger minionClothe;
    public GameObject shopPanel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        anim = minion.GetComponent<Animator>();
        minionClothe = minion.GetComponent<MinionStateChanger>();
    }

    void OnEnable() {
        minion.SetActive(true);
        shadow.SetActive(true);
        if (minionClothe.isSite) platform.SetActive(true);
        shopPanel.SetActive(true);
        shopPanel.GetComponent<UIShopPanel>().ShowButtons();
        anim.SetTrigger("Null");
        anim.SetTrigger("Idle1Start");
        minionClothe.SetShopState();
    }

    void OnDisable() {
        shopPanel.GetComponent<UIShopPanel>().HideButtons();
        anim.SetTrigger("Idle1Stop");
        anim.SetTrigger("Idle1Exit");
        minion.SetActive(false);
        shadow.SetActive(false);
        platform.SetActive(false);
    }
}
