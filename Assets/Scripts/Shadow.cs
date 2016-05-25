using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour {

    public GameObject body;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(body.transform.position.x, 0, body.transform.position.z);
	}
}
