using UnityEngine;
using UnityEngine.EventSystems;


public class GlassMoving : MonoBehaviour, IDragHandler
{

    RectTransform rect;

    void Awake() {
        rect = GetComponent<RectTransform>();
    }

    void Update() {
        if (Input.touchCount == 2) resizeItem();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount == 1) {
            var currentPosition = rect.position;
            currentPosition.x += eventData.delta.x;
            currentPosition.y += eventData.delta.y;
            rect.position = currentPosition;
        }     
    }

    void resizeItem()
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
            rect.localScale = new Vector3(rect.localScale.x - deltaMagnitudeDiff * 0.02f, rect.localScale.y - deltaMagnitudeDiff * 0.02f, rect.localScale.z - deltaMagnitudeDiff * 0.02f);
            if (rect.localScale.x < 1f | rect.localScale.y < 1f | rect.localScale.z < 1f) rect.localScale = new Vector3(1f, 1f, 1f);
            if (rect.localScale.x > 2.5f | rect.localScale.y > 2.5f | rect.localScale.z > 2.5f) rect.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
    }
}
