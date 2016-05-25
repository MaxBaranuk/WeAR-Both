using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

    GameObject cam;
    long count;
//    public bool is
	// Use this for initialization
	void Start () {
        cam = GameObject.Find("ARCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if (count % 10 == 0) ScalePoint();
        count++;
	}

    void ScalePoint()
    {
        float scaleMode = (cam.transform.position - transform.position).magnitude/60;                                     
        transform.localScale = Vector3.one * scaleMode*2;
    }

}
