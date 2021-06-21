using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    
    void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    //Plays the audio sound with the given name
    public void Play(string name)
    {
        //Finds a sound in the sounds array
        Sounds s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
    }
}
