using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clickSound;

    [SerializeField]
    private AudioSource audioSource;

    private static SoundManager _instance;
    public static SoundManager Instance 
    { 
        get 
        { 
            return _instance; 
        } 
    } 
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(_clickSound);
    }
}
