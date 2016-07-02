using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModelRotationManager : MonoBehaviour
{
    [SerializeField] private GameObject _interactModel;
    [SerializeField] private Camera _ARCamera;
    [SerializeField, Range(0, 20), Space] private float _rotationRate;

    public Text _text;

    private void Update()
    {
        RotateModel();
    }

    public float speed;
    public float xDeg, lerpSpeed, friction;
    Quaternion fromRotation, toRotation;

    private void RotateModel()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
            RotateTransform(Input.GetTouch(0).deltaPosition.x);
        else RotateTransform(0f);
        //if(Input.GetMouseButton(0)) 
        //    RotateTransform(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); 
        //else RotateTransform(0f, 0f); 
    }

    void RotateTransform(float xNum)
    {
        xDeg -= xNum * 2.0f * friction;
        fromRotation = _interactModel.transform.rotation;
        toRotation = Quaternion.Euler(0, -xDeg, 0);
        _interactModel.transform.rotation = Quaternion.Lerp(fromRotation, toRotation, 1);
    }
}
