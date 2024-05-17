using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /*public AudioClip[] clips;
    public AudioSource audioSource;
    public CarScriptable car;
    *//*
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
        }*//*
    private void Awake()
    {
        GameManager.onGameStarted += StarTcar;
    }
    public  void StarTcar()
    {
  
        audioSource.PlayOneShot(car.EngineSound);
    }*/

    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;
    private Rigidbody rb;
    private AudioSource audioSource;
    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;
    private void Start()
    {
        audioSource=GetComponent<AudioSource>();
        rb=GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Enginesound();
    }
    void Enginesound()
    {
        currentSpeed = rb.velocity.magnitude;
        pitchFromCar =rb.velocity.magnitude / 20f;
        if(currentSpeed < minSpeed)
        {
           audioSource.pitch=minPitch;
        }
        if(currentSpeed > minSpeed&&currentSpeed<maxSpeed) {
            audioSource.pitch = minPitch+pitchFromCar;
        }
        if (currentSpeed > maxSpeed)
        {
            audioSource.pitch = maxPitch;
        }
    }
}