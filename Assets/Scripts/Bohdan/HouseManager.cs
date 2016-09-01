using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HouseManager : MonoBehaviour
{

    [SerializeField] private GameObject _plan;
    [SerializeField] private GameObject _house;
    [SerializeField] private GameObject _houseButton;
    [SerializeField] private GameObject _planButton;
    [SerializeField] private Animator _animator;
    [SerializeField] private Camera _camera;

    public void ShowPlan()
    {
        SetActive(_house);
        SetActive(_plan);
        SetActive(_houseButton);
        SetActive(_planButton);
        _animator.SetTrigger("Plan");
    }

    public void ShowHouse()
    {
        SetActive(_house);
        SetActive(_plan);
        SetActive(_houseButton);
        SetActive(_planButton);
        _animator.SetTrigger("House");
    }

    private void SetActive(GameObject go)
    {
        if (!go.activeSelf)
        {
            go.SetActive(true);
        } else go.SetActive(false);
    }

    private void Update()
    {
        Cast();
    }

    private void Cast()
    {
        if (!Application.isEditor)
        {
            Ray ray = _camera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit _hit;

            if (Physics.Raycast(ray, out _hit, 100f))
            {
                if (_hit.collider.name == _houseButton.name)
                {
                    ShowHouse();
                }
                else if (_hit.collider.name == _planButton.name)
                {
                    ShowPlan();
                }
            }
        }
    }
}
