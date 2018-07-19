using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound{
    //opis pojedynczego audio tracka niezbedny w audio managerze
    public string name;

    public AudioMixerGroup mixer;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
