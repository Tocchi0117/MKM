using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Sound_SE : MonoBehaviour
{
    public static AudioClip[] sound;
    public AudioClip[] sound_SE;

    public static AudioSource[] audioSource;
    public AudioSource[] audioSource_SE;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = audioSource_SE;
        sound = sound_SE;
    }

    public static void playsound(int audio,int index)
    {
        audioSource[audio].PlayOneShot(sound[index]);
    }
}
