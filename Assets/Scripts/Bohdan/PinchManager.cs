using UnityEngine;
using System.Collections;

public class PinchManager : MonoBehaviour
{
    [SerializeField] private GameObject _targetObject;
    
    private float _scaleFactor = 0.5f; // The rate of change of the scale
    private float _minScale = 0.6f;
    private float _maxScale = 2.0f;

    private void Update()
    {
       PinchObject();
    }
    
    private void PinchObject()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // Change the scale based on the change in distance between the touches.
            var localTemp = gameObject.transform.localScale;
            localTemp.x += deltaMagnitudeDiff * _scaleFactor;
            localTemp.y += deltaMagnitudeDiff * _scaleFactor;
            localTemp.z += deltaMagnitudeDiff * _scaleFactor;

            // Clamp the scale factor to make sure it's between _minScale and _maxScale.
            localTemp.x = Mathf.Clamp(localTemp.x, _maxScale, _minScale);
            localTemp.y = Mathf.Clamp(localTemp.y, _maxScale, _minScale);
            localTemp.z = Mathf.Clamp(localTemp.z, _maxScale, _minScale);

            _targetObject.transform.localScale = localTemp;
        }
    }
}
