using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using Facebook.Unity;
//using System.Collections.Generic;
//using System;
//using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
   
    public int totalShots = 0;
    int goalShots = 0;
    int points;
    public GameObject arCam;
    public GameObject score;
    Text scoretext;
    public GameObject gamePanel;
    //    bool isShared;
    //    bool isLoginned;
    public bool isFinishGame;
    public float timeToFinish;
    public GameObject ball;
    public GameObject minion;
    public GameObject shadow;
    public GameObject platform;
    MinionStateChanger minionClothe;
    Animator anim;
    // Use this for initialization
    void Awake () {
        scoretext = score.GetComponentInChildren<Text>();
        anim = minion.GetComponent<Animator>();
        minionClothe = minion.GetComponent<MinionStateChanger>();
    }

    void OnEnable() {
        createNewBall();

        minion.SetActive(true);
        shadow.SetActive(true);
        if (minionClothe.isSite) platform.SetActive(true);
        gamePanel.SetActive(true);
        anim.SetTrigger("Null");
        anim.SetTrigger("GameStart");
        minionClothe.SetGameClothes();

    }

    void Update () {

        scoretext.text = "" + goalShots;
        if (timeToFinish < 0) {
            timeToFinish = 0;           
            isFinishGame = true;
            
//            int perc = (int)(((float) goalShots / totalShots) * 100);
        }
    }

    public void addPoints() { 
      goalShots++;
      points += 2;
    }

    public void createNewBall() {
        StartCoroutine(createBall());
    }

    IEnumerator createBall() {
        yield return new WaitForSeconds(0.4f);
            GameObject newBall = Instantiate(ball);
            newBall.gameObject.transform.parent = arCam.transform;
            newBall.GetComponent<Rigidbody>().isKinematic = true;
            newBall.transform.localPosition = new Vector3(0, -2f, 5f);
            newBall.GetComponent<Rigidbody>().useGravity = false;
    }

    //public void startNewGame() {
    //    StartCoroutine(startgame());        
    //}

    //public void startGame() {
    //    createNewBall();
    //}

    //IEnumerator startgame() {
    //    yield return new WaitForSeconds(0.3f);
    //    goalShots = 0;
    //    points = 0;
    //    totalShots = 0;
    //    timeToFinish = 60;
    //    isFinishGame = false;
    //}

    void OnDisable() {
        gamePanel.SetActive(false);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Banana");
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
        anim.SetTrigger("GameStop");
        anim.SetTrigger("GameExit");
        minion.SetActive(false);
        shadow.SetActive(false);
        platform.SetActive(false);
    }
}
