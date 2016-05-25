using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {

    public AudioClip click;
    public AudioClip photo;
    AudioSource source;

    void Start() {
        source = GetComponent<AudioSource>();
    }
    public void ClickSound() {
        source.PlayOneShot(click);
    }

    public void PhotoSound() {
        source.PlayOneShot(photo);
    }
}
