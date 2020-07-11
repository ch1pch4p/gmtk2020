using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundName { Meow };

[System.Serializable]
public class Sound
{
    public SoundName soundName;
    public AudioClip audioClip;
    private AudioSource audioSource;
    [Range(0f, 1f)]
    public float volume = 0.8f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1.0f;
    private float variableVolume = 0.1f;
    private float variablePitch = 0.1f;

    public void SetAudioSource(AudioSource audioSource)
    {
        this.audioSource = audioSource;
        this.audioSource.clip = audioClip;
    }

    public void Play()
    {
        audioSource.volume = volume + Random.Range(-variableVolume, variableVolume);
        audioSource.pitch = pitch + Random.Range(-variablePitch, variablePitch);
        audioSource.Play();
    }
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds = new Sound[1];

    Dictionary<SoundName, Sound> soundMap = new Dictionary<SoundName, Sound>();

    void Awake()
    {
        instance = this;
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].SetAudioSource(this.gameObject.AddComponent<AudioSource>());
            soundMap.Add(sounds[i].soundName, sounds[i]);
        }
    }

    public void PlaySound(SoundName soundName)
    {
        soundMap[soundName].Play();
    }

    public Sound[] getSounds()
    {
        return sounds;
    }
}