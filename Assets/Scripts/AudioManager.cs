using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // variables for AudioManager
    public Sound[] sounds;
    public static AudioManager instance;
    
    void Awake()
    {
        // allow music to play across all scenes until stopped
        DontDestroyOnLoad(gameObject);
        
        // make sure that there is always just one AudioManager and destroy the others
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        // settings for AudioManager sounds in the editor
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            // options that are available in the editor
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // function for playing the sound file
    public void Play(string name)
    {
        // finding the right sound in the array on the AudioManager
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        // check if the file can be found
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found! :)");
            return;
        }
        
        // START playing
        s.source.Play();
        
    }

    public void Stop(string name)
    {
        // finding the right sound in the array on the AudioManager
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        // STOP playing
        s.source.Stop();
    }
    

}
