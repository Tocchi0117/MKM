using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Sound_BGM : MonoBehaviour
{
    public static AudioClip[] sound;
    public AudioClip[] sound_BGM;

    public static AudioSource audioSource;
    public AudioSource audioSource_BGM;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = audioSource_BGM;
        sound = sound_BGM;
    }

}
