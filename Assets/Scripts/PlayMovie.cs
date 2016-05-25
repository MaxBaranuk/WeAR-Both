using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour 
{
	public void PlayClip()
	{
		Handheld.PlayFullScreenMovie ("Unity 5 Launch Trailer.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	}
}
