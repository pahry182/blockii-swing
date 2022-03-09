using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float Score { get; set; }
    public new Audio audio = new Audio();
    public Setting setting = new Setting();
    public GameObject[] placedPlatforms;
    public Transform userPlacedTransformParent;

    public bool isUpdatingVolume;
    public bool isStarted, isLost;
    public int maxPlatformPlaced = 1;
    public float placedPlatformDuration = 0.7f;
    public float placedPlatformCooldown = 1f;
    [HideInInspector]public float placedPlatformCurrentCooldown = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetupAudio();
        Score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVolume();
        UpdateCooldown();
    }

    public void UpdateCooldown()
    {
        if (placedPlatformCurrentCooldown > 0)
            placedPlatformCurrentCooldown -= Time.deltaTime;
    }

    public void PlaySfx(string name)
    {
        Sound sfx = Array.Find(audio.soundEffects, sound => sound.name == name);
        if (sfx == null)
        {
            print("Audio " + name + " not found!!");
            return;
        }

        sfx.audioSource.Play();
    }

    public void PlayBgm(string name)
    {
        Sound bgm = Array.Find(audio.backgroundMusics, sound => sound.name == name);
        print(bgm.name + name);
        if (bgm.name == name && bgm.audioSource.isPlaying) return;
        if (bgm == null)
        {
            print("Audio " + name + " not found!!");
            return;
        }

        for (int i = 0; i < audio.backgroundMusics.Length; i++)
        {
            audio.backgroundMusics[i].audioSource.Stop();
        }

        bgm.audioSource.Play();
    }

    private void UpdateVolume()
    {
        if (!isUpdatingVolume) return;

        for (int i = 0; i < audio.activeSfx.Count; i++)
        {
            audio.activeSfx[i].volume = setting.SfxVolume;
        }

        for (int i = 0; i < audio.activeBgm.Count; i++)
        {
            audio.activeBgm[i].volume = setting.BgmVolume;
        }
    }

    private void SetupAudio()
    {
        for (int i = 0; i < audio.soundEffects.Length; i++)
        {
            audio.soundEffects[i].audioSource = gameObject.AddComponent<AudioSource>();
            audio.soundEffects[i].audioSource.clip = audio.soundEffects[i].clip;
            audio.soundEffects[i].audioSource.volume = audio.soundEffects[i].volume;
            audio.soundEffects[i].audioSource.pitch = audio.soundEffects[i].pitch;
            audio.soundEffects[i].audioSource.loop = audio.soundEffects[i].loop;
            audio.activeSfx.Add(audio.soundEffects[i].audioSource);
        }

        for (int i = 0; i < audio.backgroundMusics.Length; i++)
        {
            audio.backgroundMusics[i].audioSource = gameObject.AddComponent<AudioSource>();
            audio.backgroundMusics[i].audioSource.clip = audio.backgroundMusics[i].clip;
            audio.backgroundMusics[i].audioSource.volume = audio.backgroundMusics[i].volume;
            audio.backgroundMusics[i].audioSource.pitch = audio.backgroundMusics[i].pitch;
            audio.backgroundMusics[i].audioSource.loop = audio.backgroundMusics[i].loop;
            audio.activeBgm.Add(audio.backgroundMusics[i].audioSource);
        }
    }

    public void ToggleMusic(bool value)
    {
        for (int i = 0; i < audio.backgroundMusics.Length; i++)
        {
            audio.backgroundMusics[i].audioSource.mute = value;
        }
    }

    public void ToggleEffects(bool value)
    {
        for (int i = 0; i < audio.soundEffects.Length; i++)
        {
            audio.soundEffects[i].audioSource.mute = value;
        }
    }

    [Serializable]
    public class Audio
    {
        public Sound[] soundEffects;
        public Sound[] backgroundMusics;

        [HideInInspector] public List<AudioSource> activeSfx = new List<AudioSource>();
        [HideInInspector] public List<AudioSource> activeBgm = new List<AudioSource>();
    }

    [Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 0.7f)] public float volume = 0.7f;
        [Range(0.1f, 3f)] public float pitch;
        public bool loop;
        [HideInInspector] public AudioSource audioSource;
    }

    public class Setting
    {
        public float SfxVolume
        {
            get { return PlayerPrefs.GetFloat("sfxVolume"); }
            set { PlayerPrefs.SetFloat("sfxVolume", value); }
        }

        public float BgmVolume
        {
            get { return PlayerPrefs.GetFloat("bgmVolume"); }
            set { PlayerPrefs.SetFloat("bgmVolume", value); }
        }

        public float SfxStatus
        {
            get { return PlayerPrefs.GetInt("sfxStatus"); }
            set { PlayerPrefs.SetInt("sfxStatus", (int)value); }
        }

        public float BgmStatus
        {
            get { return PlayerPrefs.GetInt("bgmStatus"); }
            set { PlayerPrefs.SetInt("bgmStatus", (int)value); }
        }
    }

}
