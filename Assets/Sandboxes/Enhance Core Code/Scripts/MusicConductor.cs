using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicConductor : MonoBehaviour
{
    public static MusicConductor Instance { set; get; }

    public AudioSource musicSource;

    public float songBpm;                                           //This is determined by the song you're trying to sync up to
    public float secPerBeat;                                        //The number of seconds for each song beat
    public float songPosition;                                      //Current song position, in seconds
    public float songPositionInBeats;                               //Current song position, in beats
    public float dspSongTime;                                       //How many seconds have passed since the song started
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    void Start()
    {
        musicSource = GetComponent<AudioSource>();                  //Load the AudioSource attached to the Conductor GameObject
        secPerBeat = 60f / songBpm;                                 //Calculate the number of seconds in each beat
                         //Record the time when the music starts
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !musicSource.isPlaying)
        {
            dspSongTime = (float)AudioSettings.dspTime;
            musicSource.Play();
        }

        UpdateSongInformation();
    }

    private void UpdateSongInformation()
    {
        if (!musicSource.isPlaying) return;

        songPosition = (float)(AudioSettings.dspTime - dspSongTime);    //determine how many seconds since the song started
        songPositionInBeats = songPosition / secPerBeat;                //determine how many beats since the song started
    }

}
