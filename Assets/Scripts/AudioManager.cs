using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audioSource;

    public bool start_song;
    // audioSource = GetComponent<AudioSource>();
    public GameObject unmute_btn;
    public GameObject mute_btn;
    void Start()
    {
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        // Set a default clip if needed

    }

    void PlayRandomSong()
    {
        if (!start_song || clips.Length == 0) return;

        int randomIndex = Random.Range(0, clips.Length);
        audioSource.clip = clips[randomIndex];
        audioSource.Play();
    }

    public void play_song()
    {
        start_song = true;
        mute_btn.SetActive(false);
        unmute_btn.SetActive(true);
        PlayRandomSong();
    }

    public void mute()
    {
        start_song = false;
      
        mute_btn.SetActive(true);
        unmute_btn.SetActive(false);
       audioSource.Stop();
    }
}