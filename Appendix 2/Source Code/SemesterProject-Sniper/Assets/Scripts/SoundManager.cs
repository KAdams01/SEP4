using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance = null;
    private AudioSource source;
    [SerializeField] private List<AudioClip> clips;
    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)
        {
            //if not, set instance to this
            Instance = this;
        }
        //If instance already exists and it's not this:
        else if (Instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene

    }

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayAudioClipByName(string name)
    {
        foreach (var clip in clips)
        {
            if (name == clip.name)
            {
                source.PlayOneShot(clip);
                return;
            }
            Debug.Log("Audio Clip not found.");
        }
    }
    public void PlayAudioClip(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
