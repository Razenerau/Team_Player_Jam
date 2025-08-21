using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    STEP,
    JUMP,
    SPLAT,
    ROCKET,
    FUEL,
    LAND,

    DOOR_OPEN,
    DOOR_LOCKED
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource AudioSource;
    public AudioSource RocketAudioSource;
    [SerializeField] private AudioClip[] _soundList;
    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public static void PlaySound(SoundType sound, float volume = 1f)
    {
        Instance.AudioSource.PlayOneShot(Instance._soundList[(int)sound], volume);
    }

    public static void StartRocketSound(SoundType sound = SoundType.ROCKET, float volume = 1f, float pitch = 1f)
    {
        AudioSource source = Instance.RocketAudioSource;
        source.clip = Instance._soundList[(int)sound];
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
    public static void StopRocketSound(SoundType sound = SoundType.ROCKET, float volume = 1f, float pitch = 1f)
    {
        AudioSource source = Instance.RocketAudioSource;
        source.Stop();
    }

    public bool IsPlaying()
    {
        if (Instance.RocketAudioSource.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
