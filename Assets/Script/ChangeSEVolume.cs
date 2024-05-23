using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// "AudioSource"コンポーネントがアタッチされていない場合アタッチ
[RequireComponent(typeof(AudioSource))]
public class ChangeSEVolume : MonoBehaviour
{
    public Slider slider2;
    public AudioSource[] audioSource2;

    public AudioClip sound1;

    public void Start()
    {
        for(int i = 0; i < audioSource2.Length; i++)
        {
            audioSource2[i].volume = PlayerPrefs.GetFloat("SE_Volume");
        }
        slider2.value = PlayerPrefs.GetFloat("SE_Volume");
    }

    public void SoundSliderOnValueChange2(float newSliderValue2)
    {
        for(int i = 0;i < audioSource2.Length; i++)
        {
            audioSource2[i].volume = newSliderValue2 / slider2.maxValue;
        }
        PlayerPrefs.SetFloat("SE_Volume", newSliderValue2);
        PlayerPrefs.Save();
    }

    public void sliderChange()
    {
        audioSource2[0].PlayOneShot(sound1);
    }

}
