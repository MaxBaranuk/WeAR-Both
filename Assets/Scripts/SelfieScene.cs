using UnityEngine;
using Vuforia;

public class SelfieScene : MonoBehaviour {

    public static SelfieScene instance;

	public GameObject selfiePanel;
    public GameObject galaryPanel;
    public GameObject target;
    
    void Awake() {
        if (instance == null)
        {
            instance = this;          
        }
    }

    void OnEnable() {
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);
        CameraDevice.Instance.Start();
        SceneStateManager.instance.isSelfieMode = true;
        selfiePanel.SetActive(true);
        target.SetActive(false);
    }

    void OnDisable()
    {
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_DEFAULT);
        CameraDevice.Instance.Start();
        SceneStateManager.instance.isSelfieMode = false;
        selfiePanel.SetActive(false);
        galaryPanel.SetActive(false);
    }

}
