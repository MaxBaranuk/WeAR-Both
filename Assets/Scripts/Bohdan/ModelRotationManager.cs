using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModelRotationManager : MonoBehaviour
{
    [SerializeField] private GameObject _interactModel;

    public float speed;
    public float xDeg, lerpSpeed, friction;
    Quaternion fromRotation, toRotation;
    
    private void Update()
    {
        RotateModel();

        AutoRotate();
    }

    private void RotateModel()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            RotateTransform(Input.GetTouch(0).deltaPosition.x);
//        else RotateTransform(0f);
    }

    private void RotateTransform(float xNum)
    {
        xDeg -= xNum * speed * friction;
        fromRotation = _interactModel.transform.rotation;
        toRotation = Quaternion.Euler(0, xDeg, 0);
        _interactModel.transform.rotation = Quaternion.Lerp(fromRotation, toRotation, lerpSpeed);
    }

    private void AutoRotate()
    {
        _interactModel.transform.Rotate(0f, 10f * Time.deltaTime, 0f);
    }
}
