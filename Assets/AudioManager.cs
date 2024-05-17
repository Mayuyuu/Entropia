using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Source---------")]
    [SerializeField] AudioSource musicSource,SFXSource;
 

    [Header("----------Audio Clip---------")]
    public AudioClip background,death,checkpoint,portalIn,portalOut,ButtonUi;
 

    public static AudioManager _Instance;
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
