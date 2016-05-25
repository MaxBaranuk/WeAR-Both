using UnityEngine;

public class Ball : MonoBehaviour {

    GameObject cam;
    public bool isStay = true;
    Vector2 startPos;
    Vector2 endPos;
    Vector3 ballDir;
    GameManager manager;
	// Use this for initialization
	void Start () {
        cam = GameObject.Find("ARCamera");

        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -15&& !isStay) Destroy(gameObject);     
        if (isStay ) shotListener();       
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "winDetector")
        {
            manager.addPoints();
            Destroy(gameObject);
        }
    }
    void shotListener()
    {
        if (Input.touchCount > 0 & !manager.isFinishGame)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) startPos = touch.position;
            
            if (touch.phase == TouchPhase.Moved)
            {
                float hor = 3 * touch.deltaPosition.x;
                float vert = 3 * touch.deltaPosition.y;
                transform.RotateAround(transform.position, cam.transform.Find("Camera").right * vert, 200 * Time.deltaTime);
                transform.RotateAround(transform.position, -cam.transform.Find("Camera").up * hor, 200 * Time.deltaTime);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                
                endPos = touch.position;
                Vector2 dir = endPos - startPos;
                if (dir.y > 50) makeShot(dir);              
            }
        }
    }

    void makeShot(Vector2 dir)
    {
        manager.totalShots++;
        isStay = false;
        
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;

        ballDir = cam.transform.Find("Camera").forward;
        ballDir.y = ballDir.y + 0.5f;
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody>().AddForce(ballDir * dir.y / 12, ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().AddTorque(cam.transform.Find("Camera").up * dir.y / 4);
        gameObject.GetComponent<Rigidbody>().AddTorque(-cam.transform.Find("Camera").right * dir.x / 4);
        manager.createNewBall();
    }
}
