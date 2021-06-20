using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    // variables for the AudioManager settings
    public string name; // name of the audio file
    
    public AudioClip clip; // reference to the audio file 
    
    [Range(0f, 1f)]
    public float volume; // volume of the audio file from 0 to 1 - 1 is original volume
    
    [Range(.1f, 3f)]
    public float pitch; // pitch of the audio file from 0 to 3 - 1 is normal

    public bool loop; // checkbox for looping the audio file
    
    [HideInInspector]
    public AudioSource source; // AudioSource component that gets created by the AudioManager

}