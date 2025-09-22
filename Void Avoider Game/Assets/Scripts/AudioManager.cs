using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip victoryMusic;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private float musicVolume = 0.3f;

    [SerializeField] private List<SoundEffect> soundEffects;

    public AudioClip VictoryMusic => victoryMusic;
    public AudioClip MenuMusic => menuMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
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

    public void ChangeBackgroundMusic(AudioClip newClip, float newVolume = -1f, bool loop = true)
    {
        if (musicSource == null || newClip == null) return;

        musicSource.Stop();
        musicSource.clip = newClip;

        if (newVolume >= 0f)
            musicSource.volume = newVolume;
        else
            musicSource.volume = musicVolume; // default volume

        musicSource.loop = loop;
        musicSource.Play();
    }

    public void ResetBackgroundMusic()
    {
        if (musicSource == null || backgroundMusic == null) return;

        ChangeBackgroundMusic(backgroundMusic, musicVolume, true);
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
