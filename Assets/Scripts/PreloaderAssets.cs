using UnityEngine;
using System.Collections;

public class PreloaderAssets : MonoBehaviour {

    public void Load() {
        string expPath = GooglePlayDownloader.GetExpansionFilePath();
        string mainPath = GooglePlayDownloader.GetMainOBBPath(expPath);
        string patchPath = GooglePlayDownloader.GetPatchOBBPath(expPath);
        if (mainPath == null || patchPath == null)
                GooglePlayDownloader.FetchOBB();
       
    }
}
