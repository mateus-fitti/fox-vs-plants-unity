﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioMixerGroup mixer;
    public List<Sound> sounds;
    public float mainVolume = 0.3f;
    
    public static SoundManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        SetSoundSources();

        Play("Music");
    }

    void SetSoundSources()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = mixer;
            s.source.volume = mainVolume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play (string name)
    {
        Sound s = sounds.Find(sound => sound.name == name);
        if (s == null) return;

        if (s.single) StopAllSounds();
        
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = sounds.Find(sound => sound.name == name);
        if (s == null) return;
        s.source.Stop();
    }


    public void StopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            if (s == null) return;
            s.source.Stop();
        }
    }
}
