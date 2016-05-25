using UnityEngine;
using System.Collections;

public class DefaultScene : MonoBehaviour {

    public Animator anim;
    MinionStateChanger minionClothe;
    public GameObject minion;
    public GameObject shadow;
    public GameObject platform;
    // Use this for initialization

    void Awake() {
        minionClothe = minion.GetComponent<MinionStateChanger>();
    }

    void OnEnable() {
        minion.SetActive(true);
        shadow.SetActive(true);
        if (minionClothe.isSite) platform.SetActive(true);
        minionClothe.SetDefaultClothes();
        anim.SetTrigger("Null");
        anim.SetTrigger("Idle2");
    }
	
	// Update is called once per frame
	void OnDisable() {
        anim.SetTrigger("Null");
        minion.SetActive(false);
        shadow.SetActive(false);
        platform.SetActive(false);
    }
}
