using UnityEngine;
using System.Collections;

public class TV : MonoBehaviour {

    //
    public EducationView manager;
    public string link;
//    VideoPlaybackBehaviour video;
//    public GameObject infoPanel;
// Use this for initialization
    void Start () {
//        manager = GameObject.Find("InfoManager").GetComponent<EducationView>();
//        video = GetComponentInChildren<VideoPlaybackBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {
        UserInput();
    }

    public void ShowTv() {

        // fullscreen
        Handheld.PlayFullScreenMovie(link, Color.black, FullScreenMovieControlMode.CancelOnInput);
//        manager.infoPanels.SetActive(true);
//        manager.Ipanels[4].SetActive(false);
        // TV
        //       gameObject.SetActive(true);
        //        StartCoroutine(moveDown());
    }

    //IEnumerator moveDown() {
    //    WaitForSeconds w = new WaitForSeconds(0.01f);
    //    while (transform.position.y > 4.6) {
    //        transform.position = new Vector3(0, transform.position.y-0.8f, 0);
    //        yield return w;
    //    }
    //    transform.position = new Vector3(0,4.6f, 0);

    //    VideoPlaybackBehaviour video = GetComponentInChildren<VideoPlaybackBehaviour>();

    //    if (video != null && video.AutoPlay)
    //    {
    //        if (video.VideoPlayer.IsPlayableOnTexture())
    //        {
    //            VideoPlayerHelper.MediaState state = video.VideoPlayer.GetStatus();
    //            if (state == VideoPlayerHelper.MediaState.PAUSED ||
    //                state == VideoPlayerHelper.MediaState.READY ||
    //                state == VideoPlayerHelper.MediaState.STOPPED)
    //            {
    //                // Pause other videos before playing this one
    //                PauseOtherVideos(video);

    //                // Play this video on texture where it left off
    //                video.VideoPlayer.Play(false, 0);
    //            }
    //            else if (state == VideoPlayerHelper.MediaState.REACHED_END)
    //            {
    //                // Pause other videos before playing this one
    //                PauseOtherVideos(video);

    //                // Play this video from the beginning
    //                video.VideoPlayer.Play(false, 0);
    //            }
    //        }
    //    }

    //}

    //IEnumerator MoveUp() {
    //    VideoPlaybackBehaviour video = GetComponentInChildren<VideoPlaybackBehaviour>();
    //     WaitForSeconds w = new WaitForSeconds(0.01f);
    //    while (transform.position.y < 30)
    //    {
    //        transform.position = new Vector3(0, transform.position.y + 0.8f, 0);
    //        yield return w;
    //    }
    //    transform.position = new Vector3(0, 30, 0);
    //    gameObject.SetActive(false);
    //    manager.infoPanels.SetActive(true);
    //    video.VideoPlayer.SeekTo(0);
    //}

    //public void HideTv() {    
    //    StartCoroutine(MoveUp());
    //}

    //private void PauseOtherVideos(VideoPlaybackBehaviour currentVideo)
    //{
    //    VideoPlaybackBehaviour[] videos = (VideoPlaybackBehaviour[])
    //            FindObjectsOfType(typeof(VideoPlaybackBehaviour));

    //    foreach (VideoPlaybackBehaviour video in videos)
    //    {
    //        if (video != currentVideo)
    //        {
    //            if (video.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
    //            {
    //                video.VideoPlayer.Pause();
    //            }
    //        }
    //    }
    //}

    void UserInput()
    {

        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Click");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.transform.gameObject.tag == "TV")
                    {
  //                      HideTv();
                    }
                }

            }
        }
        else {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                    if (hit.transform.gameObject.tag == "TV")
                    {
//                        HideTv();
                    }
            }
        }
    }

}
