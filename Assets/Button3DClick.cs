using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class Button3DClick : MonoBehaviour {

    private Touch mobileTouch;

    [SerializeField] private Camera arCamera;

    void Update ()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit hit = new RaycastHit();
                Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(i).position);

                if (Physics.Raycast(ray, out hit))
                {
                    switch (hit.collider.name)
                    {
                        case "facebook":
                            {
                                Application.OpenURL("https://www.facebook.com/MasterAD.Ukraine?ref=ts&fref=ts");
                                break;
                            }
                        case "instagram":
                            {
                                Application.OpenURL("https://www.instagram.com/masterad_/");
                                break;
                            }
                        case "web":
                            {
                                Application.OpenURL("http://masterad.com.ua/");
                                break;
                            }
                        case "twitter":
                            {
                                Application.OpenURL("https://twitter.com/MasterAdUkraine");
                                break;
                            }
                        case "facebookW":
                            {
                                Application.OpenURL("https://www.facebook.com/wearstudio68/");
                                break;
                            }
                        case "instagramW":
                            {
                                Application.OpenURL("https://www.instagram.com/wear_studio/");
                                break;
                            }
                        case "webW":
                            {
                                Application.OpenURL("http://wear-studio.com/");
                                break;
                            }
                        case "linkedinW":
                            {
                                Application.OpenURL("https://www.linkedin.com/company/wear-studio?trk=top_nav_home");
                                break;
                            }
                    }
                }
            }
        }
    }
}
