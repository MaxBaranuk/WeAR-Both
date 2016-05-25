using UnityEngine;
using System.Collections;

public class ItemScale : MonoBehaviour {

    long scaleCounter = 0;
    float touchStartAngle;
    float startItemAngle;

    //    long moveCounter = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount == 1)
        {
 //           if (moveCounter % 10 == 0) {
                moveItem();
//            moveCounter++;
 //           }
        }
        if (Input.touchCount == 2)
        {
//            if (scaleCounter % 10 == 0)
 //           {
 //               resizeItem();
            RotateItem();
 //           }
//            scaleCounter++;
        }
    }

    void resizeItem()
    {
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);
        if ((touchZero.phase == TouchPhase.Moved | touchOne.phase == TouchPhase.Moved)){
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if (scaleCounter % 2 == 0){
                transform.localScale = new Vector3(transform.localScale.x - deltaMagnitudeDiff * 0.02f, transform.localScale.y - deltaMagnitudeDiff * 0.02f, transform.localScale.z - deltaMagnitudeDiff * 0.02f);
                if (transform.localScale.x < 0.1f | transform.localScale.y < 0.1f | transform.localScale.z < 0.1f) transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            scaleCounter++;
        }
    }

    void RotateItem() {
        //Touch touchZero = Input.GetTouch(0);
        //Touch touchOne = Input.GetTouch(1);
        //if ((touchZero.phase == TouchPhase.Moved | touchOne.phase == TouchPhase.Moved)){
        //    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        //    Vector2 prevRot = touchOnePrevPos - touchZeroPrevPos;
        //    Vector2 rot = touchOne.position - touchZero.position;
        //    prevRot.Normalize();
        //    rot.Normalize();
        //    float angle = Vector2.Angle(rot, prevRot);
        //    transform.RotateAround(transform.position, transform.up, angle);
        //}

        Touch touch = Input.GetTouch(0);
        Touch touch2 = Input.GetTouch(1);
        if (touch.phase == TouchPhase.Began | touch2.phase == TouchPhase.Began)
        {
            Vector2 diffSt = touch2.position - touch.position;
            touchStartAngle = Mathf.Atan2(diffSt.y, diffSt.x);
            startItemAngle = transform.eulerAngles.y;
            //            corr = angle - transform.eulerAngles.y;
            //  corr = 

        }

        if (touch.phase == TouchPhase.Moved | touch2.phase == TouchPhase.Moved)
        {
            Vector2 diff = touch2.position - touch.position;
            //           Vector2 diff2 = touch2.position + touch2.deltaPosition - touch.position + touch.deltaPosition;
            float angle = touchStartAngle - Mathf.Atan2(diff.y, diff.x);

            //            float angle2 = Mathf.Atan2(diffSt.y, diffSt.x);
            //            float dif = angle2 - angle;

            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, startItemAngle + Mathf.Rad2Deg * angle, transform.eulerAngles.z);
        }
    }


    void moveItem()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            float hor = 0.2f *transform.localScale.x * touch.deltaPosition.x;
            float vert = 0.2f * transform.localScale.z * touch.deltaPosition.y;
            transform.position = new Vector3(transform.position.x + hor, transform.position.y, transform.position.z + vert);
        }
    }

}
