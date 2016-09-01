using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModelRotationManager : MonoBehaviour
{
    [SerializeField] private GameObject _interactModel;

    public float speed;
    public float xDeg, lerpSpeed, friction;
    Quaternion fromRotation, toRotation;
    int scaleCounter;

    void OnEnable()
    {
        Invoke("DisableAnimator", 1.5f);
    }

    void DisableAnimator()
    {
        //GetComponent<Animator>().enabled = false;
    }

    private void Update()
    {
        RotateModel();
        resizeItem();
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

    void resizeItem()
    {
        if (!Application.isEditor)
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

                if (scaleCounter%2 == 0)
                {
                    transform.localScale =
                        new Vector3(transform.localScale.x - deltaMagnitudeDiff*0.02f/(Screen.height/600),
                            transform.localScale.y - deltaMagnitudeDiff*0.02f,
                            transform.localScale.z - deltaMagnitudeDiff*0.02f);
                    if (transform.localScale.x < 0.1f | transform.localScale.y < 0.1f | transform.localScale.z < 0.1f)
                        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }
                scaleCounter++;
            }
        }
    }

    void OnDisable() {
        GetComponent<Animator>().enabled = true;
    }
}
