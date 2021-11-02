using UnityEngine;
using System;

public class SoundManagement : MonoBehaviour
{
    // Single sounds that should be played
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        // make sound playable
        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
        }
    }

    /// <summary>
    /// Play certain sound
    /// </summary>
    /// <param name="name">Sound to be played</param>
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name.Equals(name));
        s.source.Play();
    }
}
