using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private float musicVolume = 0.3f;

    [SerializeField] private List<SoundEffect> soundEffects;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.volume = musicVolume;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlaySound(string name)
    {
        SoundEffect sfx = soundEffects.Find(sound => sound.name == name);
        if (sfx != null && sfx.clip != null)
        {
            AudioSource.PlayClipAtPoint(sfx.clip, Camera.main.transform.position, sfx.volume);
        }
        else
        {
            Debug.LogWarning($"Sound {name} not found!");
        }
    }
}

[System.Serializable]
public class SoundEffect
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1f;
}
