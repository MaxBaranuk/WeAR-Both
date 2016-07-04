using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinchManager : MonoBehaviour
{
    [SerializeField] private GameObject _targetObject;

    private int _scaleCounter;

    private void Update()
    {
       PinchObject(_targetObject, _scaleCounter);
    }
    
    private void PinchObject(GameObject targetObject, int scaleCounter)
    {
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);
        if ((touchZero.phase == TouchPhase.Moved | touchOne.phase == TouchPhase.Moved))
        {
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if (scaleCounter % 2 == 0)
            {
                targetObject.transform.localScale = new Vector3(targetObject.transform.localScale.x - deltaMagnitudeDiff * 0.02f, targetObject.transform.localScale.y - deltaMagnitudeDiff * 0.02f, targetObject.transform.localScale.z - deltaMagnitudeDiff * 0.02f);
                if (targetObject.transform.localScale.x < 0.1f | targetObject.transform.localScale.y < 0.1f | targetObject.transform.localScale.z < 0.1f) targetObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            scaleCounter++;
        }
    }
}
