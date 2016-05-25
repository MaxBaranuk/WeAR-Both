using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HouseMovement : MonoBehaviour 
{
 
    Vector2 startSwipePos;

	bool isChecked;

	void Update ()
	{
		UserInput ();
	}

   public void UserInput()
    {
		if (!Application.isEditor) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit, 1000))
				{
					if (hit.transform.gameObject.tag == "House") {
						isChecked = true;
					}
				}

			}

			if (Input.GetTouch (0).phase == TouchPhase.Moved && isChecked) {
				transform.Rotate (-transform.up * 20 * Input.GetTouch (0).deltaPosition.x  * Time.deltaTime);

			}
			if (Input.GetTouch (0).phase == TouchPhase.Ended) {
				isChecked = false;
			}
		}

		if (Application.isEditor) {
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit, 1000)) {

					if (hit.transform.gameObject.tag == "House") {

						isChecked = true;
						startSwipePos = Input.mousePosition;
					}
				}

			}

			if (Input.GetMouseButton (0) && isChecked) {

				transform.Rotate ( transform.up * 20f * (startSwipePos.x - Input.mousePosition.x) * Time.deltaTime, Space.World);

				startSwipePos = Input.mousePosition;

			}
			if (Input.GetMouseButtonUp (0)) {
				isChecked = false;
			}
		}

    }


}
