using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    private static SceneLoader _instance;

    public static SceneLoader Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SceneLoader>();
            }
            return _instance;
        }
    }

    [SerializeField] private string DetailPlanSceneName;
    [SerializeField] private bool IsAutoActivateSceneWhenLoad;
    [SerializeField] private Image _alphaImage;

    private bool _isChanging;

    /// <summary>
    /// Load the main scene.
    /// </summary>
    public void LoadDetailedPlanScene()
    {
//        StartCoroutine(AsyncLoadScene(DetailPlanSceneName));
        _alphaImage.gameObject.SetActive(true);
        _isChanging = true;
    }

    private void Update()
    {
        ChangeImageAlpha(_alphaImage);

        if (_alphaImage.color.a >= .99f)
            StartCoroutine(AsyncLoadScene(DetailPlanSceneName));
    }

    private void ChangeImageAlpha(Image alphaImage)
    {
        if (!_isChanging) return;


        if (alphaImage.color.a < .99f)
        {
            Color alpha = alphaImage.color;
            alpha.a += .3f * Time.deltaTime;
            alphaImage.color = alpha;
        }

      
    }

    /// <summary>
    /// Async load scene.
    /// </summary>
    /// <returns>The load scene.</returns>
    /// <param name="scene">Scene.</param>
    IEnumerator AsyncLoadScene(string scene)
    {
        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            float progress = Mathf.Clamp01(ao.progress / 0.9f);
            // Debug.Log ("Loading progress: " + (progress * 100) + "%");

            // Loading completed
            if (ao.progress == 0.9f)
            {
                // Debug.Log ("Press a key to start");

                if (!IsAutoActivateSceneWhenLoad)
                {
                    if (Input.anyKey)
                    {
                        ao.allowSceneActivation = true;
                    }
                }
                else
                {
                    ao.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}


